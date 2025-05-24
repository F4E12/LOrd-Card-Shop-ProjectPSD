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

                LoadCart();
            }
        }

        protected void LoadCart()
        {
            int userId = Convert.ToInt32(Session["UserID"]);
            var cartData = CartController.GetAllCartItems(userId);

            if(cartData !=null && cartData.Any())
            {
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
            else
            {
                alertMsg.Text = "Your cart is empty!";
                CartGv.DataSource = null;
                CartGv.DataBind();
            }

        }

        protected void CheckOutBtn_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Checkout.aspx");
        }

        protected void clearCartBtn_Click(object sender, EventArgs e)
        {
            int userId = Convert.ToInt32(Session["UserID"]);
            TransactionController.HandleCheckOut(userId);
            CartController.Checkout(userId);
            LoadCart();
        }
    }
}