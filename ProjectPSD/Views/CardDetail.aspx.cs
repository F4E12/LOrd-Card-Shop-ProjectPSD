using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectPSD.Repository;

namespace ProjectPSD.Views
{
    public partial class CardDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string selectedCardID = Request.QueryString["CardID"];

                if(int.TryParse(selectedCardID, out int cardID))
                {
                    var card = CardRepository.getCardById(cardID);


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