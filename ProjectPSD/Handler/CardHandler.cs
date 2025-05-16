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

    }
}