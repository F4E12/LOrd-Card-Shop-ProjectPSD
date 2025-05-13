using ProjectPSD.Models;
using System;
using System.Linq;


namespace ProjectPSD.Factory
{
    public class CustomerFactory
    {
        public static User CreateCustomer(string username, string email, string password, string gender, DateTime dob)
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
    }
}