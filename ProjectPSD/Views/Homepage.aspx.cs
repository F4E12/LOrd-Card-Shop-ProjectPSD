using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectPSD.Models;

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

                    using (CardShopEntities db = new CardShopEntities())
                    {
                        var userr = db.Users.FirstOrDefault(u => u.UserName == username && u.UserPassword == password);
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
                }
                else
                {
                    Response.Redirect("Login.aspx");
                    return;
                }
            }

            User user = (User)Session["User"];
            WelcomeLbl.Text = "Welcome, " + user.UserName;

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
                        <a href='Logout.aspx'>LOGOUT</a>
                        <a href='Cart.aspx' class='{(currentPage == "Cart.aspx" ? "active" : "")}'>CART</a>
                    </div>
                "));
            }
            else if (user.UserRole == "Admin")
            {
                WelcomeLbl.Text = "Welcome, Admin";

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
                        <a href='Homepage.aspx' class='{(currentPage == "Homepage.aspx" ? "active" : "")}'>Home</a>
                        <a href='ManageCard.aspx' class='{(currentPage == "ManageCard.aspx" ? "active" : "")}'>Manage Card</a>
                        <a href='ViewTransaction.aspx' class='{(currentPage == "ViewTransaction.aspx" ? "active" : "")}'>View Transaction</a>
                        <a href='TransactionReport.aspx' class='{(currentPage == "TransactionReport.aspx" ? "active" : "")}'>Transaction Report</a>
                        <a href='Logout.aspx'>LOGOUT</a>
                        <a href='OrderQueue.aspx' class='{(currentPage == "OrderQueue.aspx" ? "active" : "")}'>Order Queue</a>
                    </div>
                "));
            }
        }
    }
}
