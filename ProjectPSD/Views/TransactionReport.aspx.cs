using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectPSD.Controller;
using ProjectPSD.Models;
using ProjectPSD.Dataset;

namespace ProjectPSD.Views
{
    public partial class TransactionReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TransactionReport report = new TransactionReport();
            ReportViewer.ReportSource = report;
            DataSet dataSet = GetData(TransactionController.GetallTransactionHeader());
        }

        private DataSet GetData(List<TransactionHeader> Transactions)
        {
            DataSet data = new DataSet();
            var headerTable = data.TransactionHeader;
            var detailTable = data.TransactionDetail;

            foreach(TransactionHeader t in Transactions)
            {
                var headerRow = headerTable.NewRow();
                headerRow["TransactionID"] = t.TransactionID;
                headerRow["CustomerID"] = t.CustomerID;
                headerRow["TransactionDate"] = t.TransactionDate;
                headerRow["GrandTotal"] = getGrandTotal(t);
                headerTable.Rows.Add(headerRow);

                foreach (Models.TransactionDetail d in t.TransactionDetails)
                {
                    var detailRow = detailTable.NewRow();
                    detailRow["TransactionID"] = d.TransactionID;
                    detailRow["CardID"] = d.CardID;
                    detailRow["Quantity"] = d.Quantity;
                    detailRow["SubTotal"] = Convert.ToInt32(d.Card.CardPrice) * d.Quantity;
                    detailTable.Rows.Add(detailRow);
                }
            }
            return data;


        }

        private int getGrandTotal(TransactionHeader t)
        {
            int total = 0;
            foreach(Models.TransactionDetail d in t.TransactionDetails)
            {
                total += d.Quantity * Convert.ToInt32(d.Card.CardPrice);
            }
            return total;
        }
    }
}