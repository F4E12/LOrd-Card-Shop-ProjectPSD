using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ProjectPSD.Models;

namespace ProjectPSD.Repository
{
    public class CartRepository
    {
        protected static CardShopEntities db = new CardShopEntities();

        public static List<Cart> GetCartByUserId(int userId)
        {
            return db.Carts.Include(c => c.Card).Where(c => c.UserID == userId).ToList();
        }

        public static Cart GetCartByCardId(int cardId)
        {
            return db.Carts.Where(c => c.CardID.Equals(cardId)).FirstOrDefault();
        }

        public static Cart GetCartByCardIdAndUserId(int cardId, int userId)
        {
            return db.Carts.FirstOrDefault(c => c.CardID == cardId && c.UserID == userId);
        }


        public static void InsertCart(Cart cart)
        {
            db.Carts.Add(cart);
            db.SaveChanges();

            return;
        }

        public static Cart AddCartQuantitiy(int cartId, int quantity)
        {
            Cart cart = db.Carts.Find(cartId);

            cart.Quantity += quantity;
            db.SaveChanges();

            return cart;

        }

        public static List<Cart> ClearCart(int userId)
        {
            var items = db.Carts.Where(c => c.UserID == userId).ToList();
            db.Carts.RemoveRange(items);
            db.SaveChanges();
            return items;
        }
        public static int GenerateNewCartID()
        {
            Cart cart = db.Carts.ToList().LastOrDefault();
            if (cart == null)
            {
                return 1;
            }
            else return cart.CartID + 1;
        }
    }
}