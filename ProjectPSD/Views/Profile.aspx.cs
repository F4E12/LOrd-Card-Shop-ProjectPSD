using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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

                User user = (User)Session["User"];
                string currentPage = System.IO.Path.GetFileName(Request.Url.AbsolutePath);

                if (user.UserRole == "Customer")
                {
                    NavbarPH.Controls.Add(new LiteralControl($@"
                <style>
                    .navbar a {{
                        margin-right: 15px;
                        color: black;
                        text-decoration: none;
                        font-weight: bold;
                        font-size: 18px;
                    }}

                    .navbar a:hover {{
                        text-decoration: underline;
                    }}

                    .navbar a.active {{
                        color: blue;
                        text-decoration: underline;
                        font-weight: bold;
                    }}
                </style>
                <div class='navbar'>
                    <a href='Homepage.aspx' class='{(currentPage == "Homepage.aspx" ? "active" : "")}'>HOME</a>
                    <a href='OrderCard.aspx' class='{(currentPage == "OrderCard.aspx" ? "active" : "")}'>ORDERCARD</a>
                    <a href='Profile.aspx' class='{(currentPage == "Profile.aspx" ? "active" : "")}'>PROFILE</a>
                    <a href='History.aspx' class='{(currentPage == "History.aspx" ? "active" : "")}'>HISTORY</a>
                    <a href='Logout.aspx' class='{(currentPage == "Logout.aspx" ? "active" : "")}'>LOGOUT</a>
                    <a href='Cart.aspx' class='{(currentPage == "Cart.aspx" ? "active" : "")}'>CART</a>
                </div>
            "));
                }

                int userId = (int)Session["UserID"];
                var userData = CustomerRepository.GetUserById(userId);

                if (userData != null)
                {
                    txtUsername.Text = userData.UserName;
                    txtEmail.Text = userData.UserEmail;
                    txtPassword.Attributes["value"] = userData.UserPassword;
                    ddlGender.SelectedValue = userData.UserGender;
                }
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
            var user = CustomerRepository.GetUserById(userId);

            string username = txtUsername.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();
            string gender = ddlGender.SelectedValue;
            string oldPassword = txtOldPassword.Text.Trim();
            string newPassword = txtNewPassword.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim();

            if (username.Length < 5 || username.Length > 30 || !System.Text.RegularExpressions.Regex.IsMatch(username, @"^[A-Za-z ]+$"))
            {
                lblMessage.Text = "Username must be 5-30 characters and alphabet only.";
                return;
            }

            if (!email.Contains("@"))
            {
                lblMessage.Text = "Email must contain '@'.";
                return;
            }

            if (password.Length < 8 || !System.Text.RegularExpressions.Regex.IsMatch(password, @"^[A-Za-z0-9]+$"))
            {
                lblMessage.Text = "Password must be at least 8 alphanumeric characters.";
                return;
            }

            if (string.IsNullOrEmpty(gender))
            {
                lblMessage.Text = "Please select a gender.";
                return;
            }

            if (!string.IsNullOrEmpty(oldPassword) || !string.IsNullOrEmpty(newPassword) || !string.IsNullOrEmpty(confirmPassword))
            {
                if (oldPassword != user.UserPassword)
                {
                    lblMessage.Text = "Old password is incorrect.";
                    return;
                }

                if (newPassword.Length < 8 || !System.Text.RegularExpressions.Regex.IsMatch(newPassword, @"^[A-Za-z0-9]+$"))
                {
                    lblMessage.Text = "New password must be at least 8 alphanumeric characters.";
                    return;
                }

                if (newPassword != confirmPassword)
                {
                    lblMessage.Text = "New password and confirmation do not match.";
                    return;
                }

                user.UserPassword = newPassword;
            }

            user.UserName = username;
            user.UserEmail = email;
            user.UserGender = gender;

            CustomerRepository.UpdateUser(user);
            lblMessage.ForeColor = System.Drawing.Color.Green;
            lblMessage.Text = "Profile updated successfully.";
        }
    }
}