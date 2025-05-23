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
        protected static CardShopEntities1 db = new CardShopEntities1();

        public static List<Card> GetAllCards()
        {
            return db.Cards.ToList();
        }

        public static Card GetCardById(int cardId)
        {
            return db.Cards.Find(cardId);
        }

        public static Card InsertCard(int cardID, string cardName, double cardPrice, string cardDesc, string cardType, bool isFoil)
        {
            CardFactory factory = new CardFactory();
            Card card = factory.CreateCard(cardID, cardName, cardPrice, cardDesc, cardType, isFoil);
            db.Cards.Add(card);
            db.SaveChanges();
            return card;
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

        public static Card UpdateCard(int cardID, string cardName, double cardPrice, string cardDesc, string cardType, bool isFoil)
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
                return card;
            }
            return null;
        }

        public static Card GetLastCard()
        {
            return db.Cards.ToList().LastOrDefault();
        }

    }
}