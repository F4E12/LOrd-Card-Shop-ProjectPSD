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
        protected static CartHandler cartHandler = new CartHandler();

        public static string AddCardToCart(int userId, int cardId)
        {
            return cartHandler.AddToCart(userId, cardId);
        }

        public static List<Cart> GetCartItems(int userId)
        {
            return CartRepository.GetCartByUserId(userId);
        }

        public static void Checkout(int userId)
        {
            CartHandler.ClearCart(userId);
        }
    }
}