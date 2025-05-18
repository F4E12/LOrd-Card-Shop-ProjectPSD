using System;
using System.Collections.Generic;
using ProjectPSD.Controller;
using ProjectPSD.Models;

namespace ProjectPSD.Views
{
    public partial class TransactionHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserID"] == null)
                {
                    Response.Redirect("~/Views/Login.aspx");
                    return;
                }

                refreshGrid();
            }
        }

        public void refreshGrid()
        {
            string role = Session["Role"]?.ToString();
            string userIdStr = Session["UserID"]?.ToString();

            if (role == "admin")
            {
                TransactionHistoryGV.DataSource = TransactionController.GetallTransactionHeader();
            }
            else
            {
                int userId = int.Parse(userIdStr);
                TransactionHistoryGV.DataSource = TransactionController.GetTransactionHeaderByCustomerId(userId);
            }

            TransactionHistoryGV.DataBind();
        }

        protected void TransactionHistoryGV_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewDetail")
            {
                string transactionId = e.CommandArgument.ToString();
                string role = Session["Role"]?.ToString();

                if (role == "admin")
                {
                    Response.Redirect("TransactionDetail.aspx?id=" + transactionId);
                }
                else
                {
                    Session["transactionId"] = transactionId;
                    Response.Redirect("TransactionDetail.aspx");
                }
            }
        }
    }
}