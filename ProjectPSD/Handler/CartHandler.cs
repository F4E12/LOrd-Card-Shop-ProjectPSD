using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectPSD.Factory;
using ProjectPSD.Models;
using ProjectPSD.Repository;

namespace ProjectPSD.Handler
{
    public class CartHandler
    {
        public static string AddToCart(int cardId, int userId)
        {
            Cart existingCart = CartRepository.GetCartByCardIdAndUserId(cardId, userId);

            if(existingCart != null)
            {
                CartRepository.AddCartQuantitiy(existingCart.CartID);
                return "Successfully updated card quantity!";
            }
            else
            {
                //create new cart to add new card
                Cart newCart = CartFactory.CreateCart(CartRepository.GenerateNewCartID(), cardId, userId, 1);
                CartRepository.InsertCart(newCart);
                return "Successfully added new card to cart!";
            }
        }
        public static List<Cart> GetCartItems(int userId)
        {
            return CartRepository.GetCartByUserId(userId);
        }

        public static void ClearCart(int userId)
        {
            CartRepository.ClearCart(userId);
        }
    }
}