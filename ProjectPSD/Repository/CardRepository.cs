using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectPSD.Models;

namespace ProjectPSD.Repository
{
    public class CardRepository
    {
        //define database
        protected static CardShopEntities db = new CardShopEntities();

        //get all cards
        public static List<Card> getAllCards()
        {
            return db.Cards.ToList();
        }

        //get card by id
        public static Card getCardById(int cardId)
        {
            return db.Cards.Find(cardId);
        }
    }
}