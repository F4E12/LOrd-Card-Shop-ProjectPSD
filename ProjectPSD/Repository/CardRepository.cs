using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectPSD.Factory;
using ProjectPSD.Models;

namespace ProjectPSD.Repository
{
    public class CardRepository
    {
        //define database
        protected static CardShopEntities db = new CardShopEntities();

        public static List<Card> GetAllCards()
        {
            return db.Cards.ToList();
        }

        public static Card GetCardById(int cardId)
        {
            return db.Cards.Find(cardId);
        }

        public static void InsertCard(int cardID, string cardName, int cardPrice, string cardDesc, string cardType, bool isFoil)
        {
            CardFactory factory = new CardFactory();
            Card card = factory.CreateCard(cardID, cardName, cardPrice, cardDesc, cardType, isFoil);
            db.Cards.Add(card);
            db.SaveChanges();
        }

        public static string DeleteCard(int cardId)
        {
            Card card = db.Cards.Find(cardId);
            if (card != null)
            {
                db.Cards.Remove(card);
                db.SaveChanges();
                return "Delete Success";
            }
            else
            {
                return "Delete Failed";
            }
        }

        public static void UpdateCard(int cardID, string cardName, int cardPrice, string cardDesc, string cardType, bool isFoil)
        {
            Card card = db.Cards.Find(cardID);
            if (card != null)
            {
                card.CardID = cardID;
                card.CardName = cardName;
                card.CardPrice = cardPrice;
                card.CardDesc = cardDesc;
                card.CardType = cardType;
                card.isFoil = isFoil;
                db.SaveChanges();
            }
        }
    }
}