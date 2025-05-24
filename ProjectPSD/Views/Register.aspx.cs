using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectPSD.Controller;
using ProjectPSD.Factory;
using ProjectPSD.Models;
using ProjectPSD.Repository;

namespace ProjectPSD.Views
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                Response.Redirect("~/Views/Homepage.aspx");
                return;
            }

            if (!IsPostBack)
            {
                for (int year = DateTime.Now.Year; year >= 1950; year--)
                {
                    YearDDL.Items.Add(year.ToString());
                }

                for (int month = 1; month <= 12; month++)
                {
                    MonthDDL.Items.Add(new ListItem(new DateTime(2000, month, 1).ToString("MMMM"), month.ToString()));
                }

                UpdateDayDDL();
            }
        }

        protected void MonthOrYearChanged(object sender, EventArgs e)
        {
            UpdateDayDDL();
        }

        private void UpdateDayDDL()
        {
            int year = int.Parse(YearDDL.SelectedValue);
            int month = int.Parse(MonthDDL.SelectedValue);
            int days = DateTime.DaysInMonth(year, month);

            DayDDL.Items.Clear();
            for (int day = 1; day <= days; day++)
            {
                DayDDL.Items.Add(day.ToString());
            }
        }

        protected void RegisterBtn_Click(object sender, EventArgs e)
        {
            string username = UsernameTb.Text.Trim();
            string email = EmailTb.Text.Trim();
            string password = PasswordTb.Text.Trim();
            string confirmPassword = ConfirmPasswordTb.Text.Trim();
            string gender = GenderRbl.SelectedValue;

            int day = int.Parse(DayDDL.SelectedValue);
            int month = int.Parse(MonthDDL.SelectedValue);
            int year = int.Parse(YearDDL.SelectedValue);
            DateTime dob = new DateTime(year, month, day);

            if (dob > DateTime.Now)
            {
                ErrorMsg.Text = "Date of Birth cannot be in the future.";
                return;
            }

            string validationMessage = CustomerController.ValidateRegisterForm(username, email, password, confirmPassword, gender, dob);
            if (validationMessage != null)
            {
                ErrorMsg.Text = validationMessage;
                return;
            }

            User newUser = CustomerController.CreateUser(username, email, password, gender, dob);
            bool isRegistered = CustomerController.RegisterUser(newUser);

            if (isRegistered)
            {
                User user = CustomerController.Login(username, password);
                if (user != null)
                {
                    Session["User"] = user;
                    Response.Redirect("~/Views/Homepage.aspx");
                }
                else
                {
                    ErrorMsg.Text = "Login failed after registration.";
                }
            }
            else
            {
                ErrorMsg.Text = "Registration failed. Please try again.";
            }
        }
    }
}