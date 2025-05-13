using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectPSD.Controller;
using ProjectPSD.Factory;
using ProjectPSD.Models;

namespace ProjectPSD.Views
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HttpCookie cookie = Request.Cookies["RememberMe"];
                if (cookie != null)
                {
                    UsernameTb.Text = cookie.Values["Username"];
                    PasswordTb.Attributes["value"] = cookie.Values["Password"];
                    RememberMeCb.Checked = true;
                }
            }

            if (Session["User"] == null && !Request.Url.AbsolutePath.EndsWith("Login.aspx"))
            {
                Response.Redirect("~/Views/Login.aspx");
            }
        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            string username = UsernameTb.Text;
            string password = PasswordTb.Text;

            var user = CustomerController.Login(username, password);


            if (user != null)
            {
                Session["User"] = user;
                Session["Role"] = user.UserRole;
                Session["UserID"] = user.UserID;

                if (RememberMeCb.Checked)
                {
                    HttpCookie cookie = new HttpCookie("RememberMe");
                    cookie.Values["Username"] = username;
                    cookie.Values["Password"] = password;
                    cookie.Expires = DateTime.Now.AddDays(7);
                    Response.Cookies.Add(cookie);
                }
                else
                {
                    if (Request.Cookies["RememberMe"] != null)
                    {
                        HttpCookie cookie = new HttpCookie("RememberMe");
                        cookie.Expires = DateTime.Now.AddDays(-1);
                        Response.Cookies.Add(cookie);
                    }
                }

                Response.Redirect("~/Views/Homepage.aspx");
            }
            else
            {
                ErrorMsg.Text = "Invalid username or password!";
                ErrorMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        }
    }
