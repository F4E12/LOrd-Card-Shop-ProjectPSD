using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectPSD.Handler;
using ProjectPSD.Models;

namespace ProjectPSD.Controller
{
    public class CustomerController
    {
        private static CustomerHandler handler = new CustomerHandler();

        public static User Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;
            return handler.Login(username, password);
        }

        public static User GetUserById(int userId)
        {
            if (userId <= 0)
                return null;

            return handler.GetUserById(userId);
        }

        public static string ValidateRegisterForm(string username, string email, string password, string confirmPassword, string gender)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(gender))
                return "All fields are required.";

            if (username.Length < 5 || username.Length > 30)
                return "Username must be between 5 - 30 characters!";
            if (!email.Contains("@"))
                return "Email must contain '@'.";
            if (password.Length < 8 || !password.All(char.IsLetterOrDigit))
                return "Password must be at least 8 characters and alphanumeric!";
            if (password != confirmPassword)
                return "Confirmation password must be the same as password.";
            if (string.IsNullOrEmpty(gender))
                return "Gender must not be empty.";

            return null;
        }

        public static User CreateUser(string username, string email, string password, string gender, DateTime dob)
        {
            return new User
            {
                UserName = username,
                UserEmail = email,
                UserPassword = password,
                UserGender = gender,
                UserDOB = dob,
                UserRole = "Customer"
            };
        }

        public static bool RegisterUser(User newUser)
        {
            return handler.RegisterUser(newUser);
        }
        public static void UpdateUser(User user)
        {
            handler.UpdateUser(user);
        }

        public static string ValidateUserProfile(string username, string email, string password, string gender)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(gender))
                return "All fields must be filled.";

            if (username.Length < 5 || username.Length > 30)
                return "Username must be between 5 - 30 characters!";
            if (!email.Contains("@"))
                return "Email must contain '@'.";
            if (password.Length < 8 || !password.All(char.IsLetterOrDigit))
                return "Password must be at least 8 characters and alphanumeric!";
            if (string.IsNullOrEmpty(gender))
                return "Gender must not be empty.";

            return null;
        }

        public static string ValidatePassword(string newPassword, string confirmPassword)
        {
            if (string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword))
                return "Password fields cannot be empty.";
            if (newPassword.Length < 8 || !newPassword.All(char.IsLetterOrDigit))
                return "New password must be at least 8 characters and alphanumeric.";
            if (newPassword != confirmPassword)
                return "New password and confirmation must match.";
            return null;
        }

    }
}

