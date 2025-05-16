using ProjectPSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Factory
{
    public class CardFactory
    {
        public Card CreateCard(int cardID, string cardName, double cardPrice, string cardDesc, string cardType, bool isFoil)
        {
            Card newCard = new Card();
            newCard.CardID = cardID;
            newCard.CardName = cardName;
            newCard.CardPrice = cardPrice;
            newCard.CardDesc = cardDesc;
            newCard.CardType = cardType;
            newCard.isFoil = isFoil;
            return newCard;
        }
    }
}