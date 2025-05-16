using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectPSD.Models;
using ProjectPSD.Repository;


namespace ProjectPSD.Handler
{
    public class CustomerHandler
    {
        public User Login(string username, string password)
        {
            return CustomerRepository.Login(username, password);
        }

        public User GetUserById(int userId)
        {
            return CustomerRepository.GetUserById(userId);
        }

        public void UpdateUser(User user)
        {
            CustomerRepository.UpdateUser(user);
        }

        public bool RegisterUser(User user)
        {
            return CustomerRepository.RegisterUser(user);
        }
    }
}