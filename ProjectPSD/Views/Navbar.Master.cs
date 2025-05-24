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
            if (!IsPostBack)
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
                        ShowGuestNavbar();
                        HighlightActiveNav(GetCurrentPage());
                        return;
                    }
                }

                string role = Session["Role"]?.ToString();

                if (role == "Admin")
                {
                    ManageCardBtn.Visible = true;
                    TransactionHistoryBtn.Visible = true;
                    TransactionReportBtn.Visible = true;
                    OrderQueueBtn.Visible = true;
                    ProfileBtn.Visible = true;
                    LogoutBtn.Visible = true;
                }
                else if (role == "Customer")
                {
                    OrderCardBtn.Visible = true;
                    CartBtn.Visible = true;
                    TransactionHistoryBtn.Visible = true;
                    ProfileBtn.Visible = true;
                    LogoutBtn.Visible = true;
                }
                else
                {
                    ShowGuestNavbar();
                }

                HighlightActiveNav(GetCurrentPage());
            }
        }

        private void ShowGuestNavbar()
        {
            LoginBtn.Visible = true;
            RegisterBtn.Visible = true;
        }

        private string GetCurrentPage()
        {
            return System.IO.Path.GetFileName(Request.Url.AbsolutePath).ToLower();
        }

        private void HighlightActiveNav(string currentPage)
        {
            RemoveActiveClassFromAll();

            switch (currentPage)
            {
                case "homepage.aspx":
                    HomeBtn.CssClass += " ActiveNav"; break;
                case "managecard.aspx":
                    ManageCardBtn.CssClass += " ActiveNav"; break;
                case "ordercard.aspx":
                    OrderCardBtn.CssClass += " ActiveNav"; break;
                case "cartpage.aspx":
                    CartBtn.CssClass += " ActiveNav"; break;
                case "transactionhistory.aspx":
                    TransactionHistoryBtn.CssClass += " ActiveNav"; break;
                case "transactionreport.aspx":
                    TransactionReportBtn.CssClass += " ActiveNav"; break;
                case "orderqueue.aspx":
                    OrderQueueBtn.CssClass += " ActiveNav"; break;
                case "profile.aspx":
                    ProfileBtn.CssClass += " ActiveNav"; break;
                case "login.aspx":
                    LoginBtn.CssClass += " ActiveNav"; break;
                case "register.aspx":
                    RegisterBtn.CssClass += " ActiveNav"; break;
                case "logout.aspx":
                    LogoutBtn.CssClass += " ActiveNav"; break;
            }
        }

        private void RemoveActiveClassFromAll()
        {
            HomeBtn.CssClass = HomeBtn.CssClass.Replace(" ActiveNav", "");
            ManageCardBtn.CssClass = ManageCardBtn.CssClass.Replace(" ActiveNav", "");
            OrderCardBtn.CssClass = OrderCardBtn.CssClass.Replace(" ActiveNav", "");
            CartBtn.CssClass = CartBtn.CssClass.Replace(" ActiveNav", "");
            TransactionHistoryBtn.CssClass = TransactionHistoryBtn.CssClass.Replace(" ActiveNav", "");
            TransactionReportBtn.CssClass = TransactionReportBtn.CssClass.Replace(" ActiveNav", "");
            OrderQueueBtn.CssClass = OrderQueueBtn.CssClass.Replace(" ActiveNav", "");
            ProfileBtn.CssClass = ProfileBtn.CssClass.Replace(" ActiveNav", "");
            LoginBtn.CssClass = LoginBtn.CssClass.Replace(" ActiveNav", "");
            RegisterBtn.CssClass = RegisterBtn.CssClass.Replace(" ActiveNav", "");
            LogoutBtn.CssClass = LogoutBtn.CssClass.Replace(" ActiveNav", "");
        }

        protected void Home_Click(object sender, EventArgs e) => Response.Redirect("Homepage.aspx");
        protected void ManageCard_Click(object sender, EventArgs e) => Response.Redirect("ManageCard.aspx");
        protected void OrderCard_Click(object sender, EventArgs e) => Response.Redirect("OrderCard.aspx");
        protected void Cart_Click(object sender, EventArgs e) => Response.Redirect("CartPage.aspx");
        protected void TransactionHistory_Click(object sender, EventArgs e) => Response.Redirect("TransactionHistory.aspx");
        protected void TransactionReport_Click(object sender, EventArgs e) => Response.Redirect("TransactionReport.aspx");
        protected void OrderQueue_Click(object sender, EventArgs e) => Response.Redirect("OrderQueue.aspx");
        protected void Profile_Click(object sender, EventArgs e) => Response.Redirect("Profile.aspx");
        protected void Login_Click(object sender, EventArgs e) => Response.Redirect("Login.aspx");
        protected void Register_Click(object sender, EventArgs e) => Response.Redirect("Register.aspx");
        protected void Logout_Click(object sender, EventArgs e) => Response.Redirect("Logout.aspx");
    }
}