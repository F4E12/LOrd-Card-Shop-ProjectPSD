using ProjectPSD.Handler;
using ProjectPSD.Models;
using ProjectPSD.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace ProjectPSD.Controller
{
    public class CardController
    {
        public static List<Card> GetAllCard()
        {
            return CardHandler.GetAllCard();
        }

        public static string DeleteCardById(int id)
        {
            return CardHandler.DeleteCard(id);
        }

        public static string InsertCard(string cardName, double cardPrice, string cardDesc, string cardType, bool isFoil)
        {
            if (string.IsNullOrWhiteSpace(cardName) || cardName.Length < 5 || cardName.Length > 50)
            {
                return "Name must be between 5 and 50 characters.";
            }
            foreach (char c in cardName)
            {
                if (!char.IsLetter(c) && c != ' ')
                {
                    return "Name must contain only alphabet letters and spaces.";
                }
            }

            if (cardPrice < 10000)
            {
                return "Price must be greater or equal than 10000.";
            }

            if (string.IsNullOrWhiteSpace(cardDesc))
            {
                return "Description must not be empty.";
            }
            
            if (!(cardType == "Spell" || cardType == "Monster"))
            {
                return "Type must be 'Spell' or 'Monster'.";
            }


            Card card = CardHandler.InsertCard(cardName, cardPrice, cardDesc, cardType, isFoil);
            if(card != null)
            {
                return "Success insert the card";
            }
            else
            {
                return "Failed to insert the card";
            }
        }

    }
}