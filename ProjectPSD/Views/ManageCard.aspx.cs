using ProjectPSD.Controller;
using ProjectPSD.Models;
using ProjectPSD.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectPSD.Views
{
    public partial class ManageCard : System.Web.UI.Page
    {
        public void RefreshGrid()
        {
            string filter = Request.QueryString["filter"];
            List<Card> cardList = CardController.GetAllCard();

            if (!string.IsNullOrEmpty(filter))
            {
                cardList = (from card in cardList
                            where card.CardName.Contains(filter)
                            select card).ToList();

            }
            ManageCardGV.DataSource = cardList;
            ManageCardGV.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RefreshGrid();
            }

        }

        protected void ManageCardGV_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ManageCardGV_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = ManageCardGV.Rows[e.RowIndex];
            int id = int.Parse(row.Cells[0].Text);
            string message = CardController.DeleteCardById(id);
            MessageLbl.Text = message;
            RefreshGrid();
        }

        protected void ManageCardGV_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = ManageCardGV.Rows[e.NewEditIndex];
            int id = int.Parse(row.Cells[0].Text);
            Response.Redirect("UpdatePage.aspx?id=" + id);
            RefreshGrid();
        }

        protected void InsertBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("InsertPage.aspx");
        }
    }
}