using ProjectPSD.Models;
using ProjectPSD.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Handler
{
    public class TransactionHandler
    {
        private static int GenerateTDId()
        {
            TransactionDetail td = TransactionRepository.GetLastTransactionDetail();
            if (td == null)
            {
                return 1;
            }
            return td.TransactionID + 1;
        }
        private static int GenerateTHId()
        {
            TransactionHeader th = TransactionRepository.GetLastTransactionHeader();
            if (th == null)
            {
                return 1;
            }
            return th.TransactionID + 1;
        }

        public static void InsertTransactionHeaeder(DateTime transactionDate, int customerId, string status)
        {
            TransactionRepository.InsertTransactionHeader(GenerateTHId(), transactionDate, customerId, status);
        }
        
        public static void InsertTransactionDetail(int cardId, int quantity)
        {
            TransactionRepository.InsertTransactionDetail(GenerateTDId(), cardId, quantity);
        }

        public static void HandleCheckout(int userId)
        {
            List<Cart> items = CartRepository.GetCartByUserId(userId);

            int thid = GenerateTHId();
            DateTime transactionDate = DateTime.Now;
            string status = "Unhandled";

            TransactionHeader th = TransactionRepository.InsertTransactionHeader(thid, transactionDate, userId, status);

            foreach (Cart item in items)
            {
                TransactionRepository.InsertTransactionDetail(th.TransactionID, item.CardID, item.Quantity);
            }
        }

        public static void UpdateTransactionStatus(int transId)
        {
            TransactionHeader th = TransactionRepository.GetTransactionHeader(transId);
            if(th== null) { return; }
            else
            {
                if(th.Status == "Unhandled")
                {
                    TransactionRepository.UpdateTransactionHeaderStatus(transId, "Handled");
                }
                else
                {
                    return;
                }
            }
        }

        public static List<TransactionHeader> GetAllTransactionHeader()
        {
            return TransactionRepository.GetAllTransactionHeader();
        }
        public static List<TransactionHeader> GetTransactionHeaderByCustomerId(int userId)
        {
            return TransactionRepository.GetTransactionHeaderByUserId(userId);
        }

        public static TransactionHeader GetTransactionById(int transId)
        {
            return TransactionRepository.GetTransactionHeader(transId);
        }

    }
}