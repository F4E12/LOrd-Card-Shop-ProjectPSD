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

        public static void AddOrUpdateCartItem(int userId, int cardId)
        {
            var existingCart = db.Carts.FirstOrDefault(c => c.UserID == userId && c.CardID == cardId);

            if (existingCart != null)
            {
                existingCart.Quantity += 1;
                db.Entry(existingCart).State = EntityState.Modified;
            }
            else
            {
                Cart newCart = new Cart
                {
                    CartID = GenerateNewCartID(),
                    UserID = userId,
                    CardID = cardId,
                    Quantity = 1
                };
                db.Carts.Add(newCart);
            }

            db.SaveChanges();
        }
        public static int GenerateNewCartID()
        {
            return db.Carts.Any() ? db.Carts.Max(c => c.CartID) + 1 : 1;
        }
    }
}