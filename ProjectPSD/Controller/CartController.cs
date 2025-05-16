using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectPSD.Handler;
using ProjectPSD.Repository;
using ProjectPSD.Models;

namespace ProjectPSD.Controller
{
    public class CartController
    {
        public static string AddCardToCart(int cardId, int userId)
        {
            return CartHandler.AddToCart(cardId, userId);
        }

        public static List<Cart> GetAllCartItems(int userId)
        {
            return CartHandler.GetCartItems(userId);
        }

        public static void Checkout(int userId)
        {
            CartHandler.ClearCart(userId);
        }
    }
}