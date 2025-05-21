using System;
using System.Linq;
using ProjectPSD.Models;
using ProjectPSD.Controller;

namespace ProjectPSD.Views
{
    public partial class TransactionDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int transactionId = 0;

                if (Request.QueryString["id"] != null)
                {
                    transactionId = int.Parse(Request.QueryString["id"]);
                }
                else if (Session["transactionId"] != null)
                {
                    transactionId = int.Parse(Session["transactionId"].ToString());
                }

                if (transactionId == 0)
                {
                    Response.Redirect("TransactionHistory.aspx");
                    return;
                }

                LoadTransaction(transactionId);
            }
        }

        private void LoadTransaction(int transactionId)
        {
            TransactionHeader header = TransactionController.GetTransactionById(transactionId);
            if (header == null) return;

            var details = header.TransactionDetails.Select(d => new
            {
                header.TransactionID,
                d.CardID,
                CardName = d.Card.CardName,
                CardPrice = d.Card.CardPrice,
                d.Quantity
            }).ToList();

            TransactionDetailGV.DataSource = details;
            TransactionDetailGV.DataBind();
        }

        protected void backBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("TransactionHistory.aspx");
        }
    }
}
