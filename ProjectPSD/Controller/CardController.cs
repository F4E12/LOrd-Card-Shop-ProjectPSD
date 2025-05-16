using ProjectPSD.Handler;
using ProjectPSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}