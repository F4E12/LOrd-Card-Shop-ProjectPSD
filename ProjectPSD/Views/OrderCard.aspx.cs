using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectPSD.Controller;
using ProjectPSD.Models;
using ProjectPSD.Repository;

namespace ProjectPSD.Views
{
    public partial class OrderCard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Session["UserID"] == null || Session["User"] == null)
                {
                    Response.Redirect("Login.aspx");
                    return;
                }

                User user = (User)Session["User"];
                string currentPage = System.IO.Path.GetFileName(Request.Url.AbsolutePath);

                if (user.UserRole == "Customer")
                {
                    NavbarPH.Controls.Add(new LiteralControl($@"
                    <style>
                        .navbar a {{
                            margin-right: 15px;
                            color: black;
                            text-decoration: none;
                            font-weight: bold;
                            font-size: 18px;
                        }}
                        .navbar a:hover {{
                            text-decoration: underline;
                        }}
                        .navbar a.active {{
                            color: blue;
                            text-decoration: underline;
                            font-weight: bold;
                        }}
                    </style>
                    <div class='navbar'>
                        <a href='Homepage.aspx' class='{(currentPage == "Homepage.aspx" ? "active" : "")}'>HOME</a>
                        <a href='OrderCard.aspx' class='{(currentPage == "OrderCard.aspx" ? "active" : "")}'>ORDERCARD</a>
                        <a href='Profile.aspx' class='{(currentPage == "Profile.aspx" ? "active" : "")}'>PROFILE</a>
                        <a href='History.aspx' class='{(currentPage == "History.aspx" ? "active" : "")}'>HISTORY</a>
                        <a href='Logout.aspx' class='{(currentPage == "Logout.aspx" ? "active" : "")}'>LOGOUT</a>
                        <a href='Cart.aspx' class='{(currentPage == "Cart.aspx" ? "active" : "")}'>CART</a>
                    </div>
                "));
                }

                refreshPage();
            }
        }

        protected void refreshPage()
        {
            List<Card> cardList = CardRepository.getAllCards();
            gvOrderCard.DataSource = cardList;
            gvOrderCard.DataBind();

        }

        protected void gvOrderCard_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int cardID;
            if (int.TryParse(e.CommandArgument.ToString(), out cardID))
            {
                if (e.CommandName == "ViewDetail")
                {
                    Response.Redirect("CardDetail.aspx?CardID=" + cardID);
                    refreshPage();
                }
                else if (e.CommandName == "AddToCart")
                {
                    if (Session["UserID"] != null)
                    {
                        int userID = Convert.ToInt32(Session["UserID"]);

                        string message = CartController.AddCardToCart(userID, cardID);
                        Response.Write($"<script>alert('{message}');</script>");

                    }
                    Response.Redirect("OrderCard.aspx");
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid Card ID');</script>");
            }

        }
    }
}