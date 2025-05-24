using System;
using System.Collections.Generic;
using System.Diagnostics;
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

                refreshPage();
            }
        }

        protected void refreshPage()
        {
            string filter = Request.QueryString["filter"];
            List<Card> cardList = CardRepository.GetAllCards();
            
            if (!string.IsNullOrEmpty(filter))
            {
                cardList = (from card in cardList
                            where card.CardName.Contains(filter)
                         select card).ToList();

            }

            gvOrderCard.DataSource = cardList;
            gvOrderCard.DataBind();
        }

        protected void gvOrderCard_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (int.TryParse(e.CommandArgument.ToString(), out int cardID))
            {
                if (e.CommandName == "ViewDetail")
                {
                    Response.Redirect("CardDetail.aspx?CardID=" + cardID);
                }
                else if (e.CommandName == "AddToCart")
                {
                    if (Session["UserID"] != null)
                    {
                        int userID = Convert.ToInt32(Session["UserID"]);

                        GridViewRow row = ((Button)e.CommandSource).NamingContainer as GridViewRow;
                        TextBox txtQuantity = row.FindControl("txtQuantity") as TextBox;

                        int quantity = 1;
                        if (txtQuantity != null && int.TryParse(txtQuantity.Text, out int parsedQty))
                        {
                            quantity = parsedQty;
                        }

                        string message = CartController.AddCardToCart(cardID, userID, quantity);
                        ScriptManager.RegisterStartupScript(this, GetType(), "alert", $"alert('{message}');", true);
                    }
                    Response.Redirect("OrderCard.aspx");
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Invalid Card ID');", true);
            }
        }
    }
}