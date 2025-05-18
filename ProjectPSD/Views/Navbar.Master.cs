using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectPSD.Controller;
using ProjectPSD.Models;

namespace ProjectPSD.Views
{
    public partial class Navbar : System.Web.UI.MasterPage
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

                    User user = CustomerController.Login(username, password);
                    if (user != null)
                    {
                        Session["User"] = user;
                        Session["Role"] = user.UserRole;
                        Session["UserID"] = user.UserID;
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

            User currentUser = (User)Session["User"];
            string currentPage = System.IO.Path.GetFileName(Request.Url.AbsolutePath);

            if (currentUser.UserRole == "Customer")
            {
                NavbarPH.Controls.Add(new LiteralControl($@"
                    <div class='navbar'>
                        <a href='Homepage.aspx' class='{(currentPage == "Homepage.aspx" ? "active" : "")}'>HOME</a>
                        <a href='OrderCard.aspx' class='{(currentPage == "OrderCard.aspx" ? "active" : "")}'>ORDERCARD</a>
                        <a href='Profile.aspx' class='{(currentPage == "Profile.aspx" ? "active" : "")}'>PROFILE</a>
                        <a href='TransactionHistory.aspx' class='{(currentPage == "History.aspx" ? "active" : "")}'>HISTORY</a>
                        <a href='CartPage.aspx' class='{(currentPage == "CartPage.aspx" ? "active" : "")}'>CART</a>
                        <a href='Logout.aspx'>LOGOUT</a>
                    </div>
                "));
            }
            else if (currentUser.UserRole == "Admin")
            {
                NavbarPH.Controls.Add(new LiteralControl($@"
                    <div class='navbar'>
                        <a href='Homepage.aspx' class='{(currentPage == "Homepage.aspx" ? "active" : "")}'>HOME</a>
                        <a href='ManageCard.aspx' class='{(currentPage == "ManageCard.aspx" ? "active" : "")}'>MANAGE CARD</a>
                        <a href='HandleTransaction.aspx' class='{(currentPage == "HandleTransaction.aspx" ? "active" : "")}'>VIEW TRANSACTION</a>
                        <a href='TransactionReport.aspx' class='{(currentPage == "TransactionReport.aspx" ? "active" : "")}'>TRANSACTION REPORT</a>
                        <a href='OrderQueue.aspx' class='{(currentPage == "OrderQueue.aspx" ? "active" : "")}'>ORDER QUEUE</a>
                        <a href='Profile.aspx' class='{(currentPage == "Profile.aspx" ? "active" : "")}'>PROFILE</a>
                        <a href='Logout.aspx'>LOGOUT</a>
                    </div>
                "));
            }
        }
    }
}