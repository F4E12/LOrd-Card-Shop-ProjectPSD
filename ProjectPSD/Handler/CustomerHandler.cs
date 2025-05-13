using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectPSD.Models;

namespace ProjectPSD.Handler
{
    public class CustomerHandler
    {
        public User Login(string username, string password)
        {
            using (CardShopEntities db = new CardShopEntities())
            {
                return db.Users.FirstOrDefault(u => u.UserName == username && u.UserPassword == password);
            }
        }

        public User GetUserById(int userId)
        {
            using (CardShopEntities db = new CardShopEntities())
            {
                return db.Users.FirstOrDefault(u => u.UserID == userId);
            }
        }

        public void UpdateUser(User user)
        {
            using (CardShopEntities db = new CardShopEntities())
            {
                var existingUser = db.Users.FirstOrDefault(u => u.UserID == user.UserID);
                if (existingUser != null)
                {
                    existingUser.UserName = user.UserName;
                    existingUser.UserEmail = user.UserEmail;
                    existingUser.UserPassword = user.UserPassword;
                    existingUser.UserGender = user.UserGender;
                    db.SaveChanges();
                }
            }
        }
        public bool RegisterUser(User user)
        {
            using (CardShopEntities db = new CardShopEntities())
            {
                if (db.Users.Any(u => u.UserName == user.UserName || u.UserEmail == user.UserEmail))
                    return false;

                db.Users.Add(user);

                try
                {
                    db.SaveChanges();
                    return true;
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException ex)
                {
                    ///buat debug
                    string errorMessages = "";
                    foreach (var validationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            errorMessages += $"Property: {validationError.PropertyName}, Error: {validationError.ErrorMessage}<br/>";
                        }
                    }

                    System.Diagnostics.Debug.WriteLine(errorMessages);

                    HttpContext.Current.Response.Write("<b>Validation Error:</b><br/>" + errorMessages);
                    HttpContext.Current.Response.End();

                    return false;
                }
            }
        }


    }
}