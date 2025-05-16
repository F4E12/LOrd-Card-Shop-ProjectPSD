using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectPSD.Models;
using ProjectPSD.Repository;

namespace ProjectPSD.Views
{
    public partial class CardDetail : System.Web.UI.Page
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
                        <a href='CartPage.aspx' class='{(currentPage == "CartPage.aspx" ? "active" : "")}'>CART</a>
                    </div>
                "));
                }

                string selectedCardID = Request.QueryString["CardID"];

                if(int.TryParse(selectedCardID, out int cardID))
                {
                    var card = CardRepository.GetCardById(cardID);


                    if (card != null)
                    {
                        nameLbl.Text = card.CardName;
                        priceLbl.Text = card.CardPrice.ToString("C");
                        cardTypeLbl.Text = card.CardType;
                        cardDescLbl.Text = card.CardDesc;

                    }
                    else
                    {
                        Response.Write("<script>alert('Card not found.');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Invalid Card ID.');</script>");
                }

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("OrderCard.aspx");
        }
    }
}