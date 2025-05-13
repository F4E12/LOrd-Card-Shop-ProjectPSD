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

        }

        protected void RegisterBtn_Click(object sender, EventArgs e)
        {
            string username = UsernameTb.Text.Trim();
            string email = EmailTb.Text.Trim();
            string password = PasswordTb.Text.Trim();
            string gender = GenderRbl.SelectedValue;
            string confirmPassword = ConfirmPasswordTb.Text.Trim();

            string validationMessage = CustomerController.ValidateRegisterForm(username, email, password, confirmPassword, gender);
            if (validationMessage != null)
            {
                ErrorMsg.Text = validationMessage;
                return;
            }

            DateTime dob = new DateTime(2000, 1, 1); 
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