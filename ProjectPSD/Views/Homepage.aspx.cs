using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectPSD.Models;
using ProjectPSD.Controller;


namespace ProjectPSD.Views
{
    public partial class Homepage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                HttpCookie cookie = Request.Cookies["RememberMe"];

                if (cookie != null &&
                    !string.IsNullOrEmpty(cookie.Values["Username"]) &&
                    !string.IsNullOrEmpty(cookie.Values["Password"]))
                {
                    string username = cookie.Values["Username"];
                    string password = cookie.Values["Password"];

                    User userr = CustomerController.Login(username, password);
                    if (userr != null)
                    {
                        Session["User"] = userr;
                        Session["Role"] = userr.UserRole;
                        Session["UserID"] = userr.UserID;
                    }
                    else
                    {
                        Response.Redirect("Login.aspx");
                        return;
                    }
                }
                else
                {
                    Response.Redirect("Login.aspx");
                    return;
                }
            }

            User user = (User)Session["User"];
            WelcomeLbl.Text = "Welcome, " + user.UserName;
        }
    }
}
