using ProjectPSD.Controller;
using ProjectPSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectPSD.Views
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = int.Parse(Request.QueryString["id"]);
                Card card = CardController.GetCardById(id);

                NameTb.Text = card.CardName;
                PriceTb.Text = card.CardPrice.ToString();
                DescTb.Text = card.CardDesc;
                TypeDd.SelectedValue = card.CardType;
                FoilDd.SelectedValue = card.isFoil ? "Yes" : "No";
            }
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Request.QueryString["id"]);
            string name = NameTb.Text;

            double price;
            bool isPriceValid = double.TryParse(PriceTb.Text, out price);
            if (!isPriceValid)
            {
                price = 0;
            }

            string description = DescTb.Text;

            string type = TypeDd.SelectedValue;

            bool isFoil = (FoilDd.SelectedValue == "Yes") ? true : false;
            string message = CardController.UpdateCard(id, name, price, description, type, isFoil);
            ErrorLbl.Text = message;
        }
    }
}