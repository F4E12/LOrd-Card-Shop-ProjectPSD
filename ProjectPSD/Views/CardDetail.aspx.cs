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
            if (Session["User"] == null || Session["UserID"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            if(Session["Role"]?.ToString() != "Customer")
            {
                Response.Redirect("Homepage.aspx");
                return;
            }

            if (!IsPostBack)
            {
                string selectedCardID = Request.QueryString["CardID"];

                if (int.TryParse(selectedCardID, out int cardID))
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

        protected void backBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("OrderCard.aspx");
        }
    }
}