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
        protected void Page_Load(object sender, EventArgs e)
        {
            var user = Session["User"];
            var role = Session["Role"]?.ToString();

            if (user == null || role != "Admin")
            {
                Response.Redirect("Login.aspx");
                return;
            }

            if (!IsPostBack)
            {
                RefreshGrid();
            }
        }

        public void RefreshGrid()
        {
            string filter = Request.QueryString["filter"];
            List<Card> cardList = CardController.GetAllCard();

            if (!string.IsNullOrEmpty(filter))
            {
                cardList = cardList
                    .Where(card => card.CardName.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0)
                    .ToList();
            }

            ManageCardGV.DataSource = cardList;
            ManageCardGV.DataBind();
        }

        protected void ManageCardGV_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = ManageCardGV.Rows[e.RowIndex];
            int cardId = int.Parse(row.Cells[0].Text);

            string message = CardController.DeleteCardById(cardId);
            MessageLbl.Text = message;

            RefreshGrid();
        }

        protected void ManageCardGV_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = ManageCardGV.Rows[e.NewEditIndex];
            int cardId = int.Parse(row.Cells[0].Text);

            Response.Redirect("UpdatePage.aspx?id=" + cardId);
        }

        protected void InsertBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("InsertPage.aspx");
        }
    }
}