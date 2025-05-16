using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectPSD.Controller;
using ProjectPSD.Models;

namespace ProjectPSD.Views
{
    public partial class Cart : System.Web.UI.Page
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

                LoadCart();
            }
        }

        protected void LoadCart()
        {
            int userId = Convert.ToInt32(Session["UserID"]);
            var cartData = CartController.GetCartItems(userId);

            var displayData = cartData.Select(c => new
            {
                c.Card.CardName,
                c.Card.CardPrice,
                c.Card.CardType,
                c.Card.CardDesc,
                c.Quantity
            }).ToList();

            CartGv.DataSource = displayData;
            CartGv.DataBind();
        }

        protected void CheckOutBtn_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Checkout.aspx");
        }
    }
}