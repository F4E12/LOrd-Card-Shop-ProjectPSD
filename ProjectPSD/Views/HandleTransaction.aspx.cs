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
    public partial class HandleTransaction : System.Web.UI.Page
    {

        public void RefreshGrid()
        {
            List<TransactionHeader> cards = TransactionController.GetallTransactionHeader();
            TransactionGV.DataSource = cards;
            TransactionGV.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RefreshGrid();
            }

        }

        protected void TransactionGV_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = TransactionGV.Rows[e.NewEditIndex];
            int id = int.Parse(row.Cells[0].Text);

            TransactionController.UpdateTransactionStatus(id);
            TransactionGV.EditIndex = -1;
            RefreshGrid();
        }
    }
}