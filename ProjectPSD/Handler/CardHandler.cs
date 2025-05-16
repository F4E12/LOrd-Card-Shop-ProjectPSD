using ProjectPSD.Models;
using ProjectPSD.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Handler
{
    public class CardHandler
    {
        public static List<Card> GetAllCard()
        {
            return CardRepository.GetAllCards();
        }

        public static string DeleteCard(int id)
        {
            return CardRepository.DeleteCard(id);
        }

        private static int GenerateCartId()
        {
            Card card = CardRepository.GetLastCard();
            if (card == null)
            {
                return 1;
            }
            return card.CardID + 1;
        }

        public static Card InsertCard(string cardName, double cardPrice, string cardDesc, string cardType, bool isFoil)
        {

            return CardRepository.InsertCard(GenerateCartId(), cardName, cardPrice, cardDesc, cardType, isFoil);
        }

    }
}