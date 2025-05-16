using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectPSD.Models;
using ProjectPSD.Repository;

namespace ProjectPSD.Handler
{
    public class CartHandler
    {
        protected static CardShopEntities db = new CardShopEntities();

        public string AddToCart(int userId, int cardId)
        {
            CartRepository.AddOrUpdateCartItem(userId, cardId);
            return "Card added to cart.";
        }

        public static void ClearCart(int userId)
        {
            CartRepository.ClearCart(userId);
        }
    }
}