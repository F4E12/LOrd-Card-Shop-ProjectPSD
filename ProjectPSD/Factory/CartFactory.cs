using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectPSD.Models;

namespace ProjectPSD.Factory
{
    public class CartFactory
    {
        public static Cart CreateCart(int cartId, int cardId, int userId, int quantity)
        {
            Cart newCart = new Cart
            {
                CartID = cartId,
                UserID = userId,
                CardID = cardId,
                Quantity = quantity
            };

            return newCart;
        }
    }
}