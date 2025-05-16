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
                        <a href='CartPage.aspx' class='{(currentPage == "CartPage.aspx" ? "active" : "")}'>CART</a>
                    </div>
                "));
                }

                int userId = (int)Session["UserID"];
                var userData = CustomerController.GetUserById(userId);

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
            var user = CustomerController.GetUserById(userId);

            string username = txtUsername.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();
            string gender = ddlGender.SelectedValue;
            string oldPassword = txtOldPassword.Text.Trim();
            string newPassword = txtNewPassword.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim();

            string validationMessage = CustomerController.ValidateUserProfile(username, email, password, gender);
            if (validationMessage != null)
            {
                lblMessage.Text = validationMessage;
                return;
            }

            if (!string.IsNullOrEmpty(oldPassword) || !string.IsNullOrEmpty(newPassword) || !string.IsNullOrEmpty(confirmPassword))
            {
                if (oldPassword != user.UserPassword)
                {
                    lblMessage.Text = "Old password is incorrect.";
                    return;
                }

                string passwordValidation = CustomerController.ValidatePassword(newPassword, confirmPassword);
                if (passwordValidation != null)
                {
                    lblMessage.Text = passwordValidation;
                    return;
                }

                user.UserPassword = newPassword;
            }

            user.UserName = username;
            user.UserEmail = email;
            user.UserGender = gender;

            CustomerController.UpdateUser(user);
            lblMessage.ForeColor = System.Drawing.Color.Green;
            lblMessage.Text = "Profile updated successfully.";
        }
    }
}