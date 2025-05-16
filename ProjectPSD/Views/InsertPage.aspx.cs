using ProjectPSD.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectPSD.Views
{
    public partial class InsertPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void InsertBtn_Click(object sender, EventArgs e)
        {
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

            String message = CardController.InsertCard(name, price, description, type, isFoil);
            

            if(message == "Success insert the card")
            {
                Response.Redirect("Homepage.aspx");
            }
            else
            {
                ErrorLbl.Text = message;
            }
        }
    }
}