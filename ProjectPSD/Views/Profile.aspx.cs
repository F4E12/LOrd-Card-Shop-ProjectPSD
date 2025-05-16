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
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserID"] == null || Session["User"] == null)
                {
                    Response.Redirect("Login.aspx");
                    return;
                }

                for (int year = DateTime.Now.Year; year >= 1950; year--)
                {
                    ddlYear.Items.Add(year.ToString());
                }

                for (int month = 1; month <= 12; month++)
                {
                    ddlMonth.Items.Add(new ListItem(new DateTime(2000, month, 1).ToString("MMMM"), month.ToString()));
                }

                int userId = (int)Session["UserID"];
                var userData = CustomerController.GetUserById(userId);

                if (userData != null)
                {
                    txtUsername.Text = userData.UserName;
                    txtEmail.Text = userData.UserEmail;
                    txtPassword.Attributes["value"] = userData.UserPassword;
                    ddlGender.SelectedValue = userData.UserGender;

                    ddlYear.SelectedValue = userData.UserDOB.Year.ToString();
                    ddlMonth.SelectedValue = userData.UserDOB.Month.ToString();
                    UpdateDayDDL();
                    ddlDay.SelectedValue = userData.UserDOB.Day.ToString();
                }
            }
        }

        protected void MonthOrYearChanged(object sender, EventArgs e)
        {
            UpdateDayDDL();
        }

        private void UpdateDayDDL()
        {
            if (ddlYear.SelectedValue == "" || ddlMonth.SelectedValue == "") return;

            int year = int.Parse(ddlYear.SelectedValue);
            int month = int.Parse(ddlMonth.SelectedValue);
            int days = DateTime.DaysInMonth(year, month);

            ddlDay.Items.Clear();
            for (int day = 1; day <= days; day++)
            {
                ddlDay.Items.Add(day.ToString());
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            int userId = (int)Session["UserID"];
            var user = CustomerController.GetUserById(userId);

            string username = txtUsername.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();
            string gender = ddlGender.SelectedValue;

            if (ddlDay.SelectedValue == "" || ddlMonth.SelectedValue == "" || ddlYear.SelectedValue == "")
            {
                lblMessage.Text = "Please select a valid Date of Birth.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            int day = int.Parse(ddlDay.SelectedValue);
            int month = int.Parse(ddlMonth.SelectedValue);
            int year = int.Parse(ddlYear.SelectedValue);
            DateTime dob = new DateTime(year, month, day);

            if (dob > DateTime.Now)
            {
                lblMessage.Text = "Date of Birth cannot be in the future.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            string validationMessage = CustomerController.ValidateUserProfile(username, email, password, gender, dob);
            if (validationMessage != null)
            {
                lblMessage.Text = validationMessage;
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            string oldPassword = txtOldPassword.Text.Trim();
            string newPassword = txtNewPassword.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim();

            if (!string.IsNullOrEmpty(oldPassword) || !string.IsNullOrEmpty(newPassword) || !string.IsNullOrEmpty(confirmPassword))
            {
                if (oldPassword != user.UserPassword)
                {
                    lblMessage.Text = "Old password is incorrect.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                string passwordValidation = CustomerController.ValidatePassword(newPassword, confirmPassword);
                if (passwordValidation != null)
                {
                    lblMessage.Text = passwordValidation;
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                user.UserPassword = newPassword;
            }

            user.UserName = username;
            user.UserEmail = email;
            user.UserGender = gender;
            user.UserDOB = dob;

            CustomerController.UpdateUser(user);

            Session["User"] = user;

            lblMessage.ForeColor = System.Drawing.Color.Green;
            lblMessage.Text = "Profile updated successfully.";
        }

    }
}