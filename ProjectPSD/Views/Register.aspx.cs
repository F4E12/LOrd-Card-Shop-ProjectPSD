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
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RegisterBtn_Click(object sender, EventArgs e)
        {
            String username = UsernameTb.Text;
            String email = EmailTb.Text;
            String password = PasswordTb.Text;
            String gender = GenderRbl.SelectedValue;
            String password2 = ConfirmPasswordTb.Text;

            if (username.Length < 5 || username.Length > 30)
            {
                ErrorMsg.Text = "Username must be between 5 - 30 characters!";
            }
            else if (!email.Contains("@"))
            {
                ErrorMsg.Text = "Email must contain '@'";
            }
            else if (CustomerRepository.IsUsernameExist(username))
            {
                ErrorMsg.Text = "Username already exists!";
            }
            else if (CustomerRepository.IsEmailExist(email))
            {
                ErrorMsg.Text = "Email already exists!";
            }
            else if (password.Length < 8 || !password.All(char.IsLetterOrDigit))
            {
                ErrorMsg.Text = "Password must be at least 8 characters and alphanumeric!";
            }
            else if (string.IsNullOrEmpty(gender))
            {
                ErrorMsg.Text = "Gender must not be empty!";
            }
            else if (password2 != password)
            {
                ErrorMsg.Text = "Confirmation password must be the same with password";
            }
            else
            {
                DateTime dob = new DateTime(2000, 1, 1); 

                User newUser = CustomerFactory.CreateCustomer(username, email, password, gender, dob);

                CustomerRepository.Register(newUser);

                User user = CustomerRepository.Login(username, password);
                Session["User"] = user;

                Response.Redirect("~/Views/Homepage.aspx");
            }
        }
    }
}