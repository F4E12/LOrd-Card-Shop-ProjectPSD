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
    public partial class Checkout : System.Web.UI.Page
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

            var displayData = cartData.Select(c => new
            {
                c.Card.CardName,
                c.Card.CardPrice,
                c.Card.CardType,
                c.Card.CardDesc,
                c.Quantity,
                TotalItemPrice = c.Card.CardPrice * c.Quantity
            }).ToList();

            CheckOutGv.DataSource = displayData;
            CheckOutGv.DataBind();

            double totalPrice = displayData.Sum(item => item.TotalItemPrice);
            totalLbl.Text = "Total: " + totalPrice.ToString("C");
        }

        protected void btnConfirmCheckout_Click(object sender, EventArgs e)
        {
            int userId = Convert.ToInt32(Session["UserID"]);
            TransactionController.HandleCheckOut(userId);
            CartController.Checkout(userId);

            Response.Redirect("Homepage.aspx");
        }
    }
}