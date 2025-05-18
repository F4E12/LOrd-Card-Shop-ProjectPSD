using ProjectPSD.Handler;
using ProjectPSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Controller
{
    public class TransactionController
    {
        public static void HandleCheckOut(int userId)
        {
            TransactionHandler.HandleCheckout(userId);
        }

        public static void UpdateTransactionStatus(int transId)
        {
            TransactionHandler.UpdateTransactionStatus(transId);
        }

        public static List<TransactionHeader> GetallTransactionHeader()
        {
            return TransactionHandler.GetAllTransactionHeader();
        }
        public static List<TransactionHeader> GetTransactionHeaderByCustomerId(int userId)
        {
            return TransactionHandler.GetTransactionHeaderByCustomerId(userId);
        }

    }
}