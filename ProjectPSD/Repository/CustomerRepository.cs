using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectPSD.Models;

namespace ProjectPSD.Repository
{
    public class CustomerRepository
    {
        public static bool IsUsernameExist(string username)
        {
            using (var db = new CardShopEntities())
            {
                return db.Users.Any(u => u.UserName == username);
            }
        }

        public static bool IsEmailExist(string email)
        {
            using (var db = new CardShopEntities())
            {
                return db.Users.Any(u => u.UserEmail == email);
            }
        }

        public static bool RegisterUser(User newUser)
        {
            if (IsUsernameExist(newUser.UserName) || IsEmailExist(newUser.UserEmail))
            {
                return false;
            }

            using (var db = new CardShopEntities())
            {
                db.Users.Add(newUser);
                db.SaveChanges();
            }

            return true;
        }

        public static User Login(string username, string password)
        {
            using (var db = new CardShopEntities())
            {
                return db.Users.FirstOrDefault(u => u.UserName == username && u.UserPassword == password);
            }
        }

        public static User GetUserById(int id)
        {
            using (var db = new CardShopEntities())
            {
                return db.Users.FirstOrDefault(u => u.UserID == id);
            }
        }

        public static void UpdateUser(User user)
        {
            using (var db = new CardShopEntities())
            {
                var existingUser = db.Users.FirstOrDefault(u => u.UserID == user.UserID);
                if (existingUser != null)
                {
                    existingUser.UserName = user.UserName;
                    existingUser.UserEmail = user.UserEmail;
                    existingUser.UserPassword = user.UserPassword;
                    existingUser.UserGender = user.UserGender;
                    existingUser.UserDOB = user.UserDOB;
                    db.SaveChanges();
                }
            }
        }
    }
}