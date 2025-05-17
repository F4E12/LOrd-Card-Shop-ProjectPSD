using ProjectPSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Factory
{
    public class TransactionFactory
    {
        public static TransactionHeader InsertTransactionHeader(int id, DateTime transactionDate, int customerId, string status)
        {
            TransactionHeader th = new TransactionHeader();
            th.TransactionID = id;
            th.TransactionDate = transactionDate;
            th.CustomerID = customerId;
            th.Status = status;
            return th;
        }

        public static TransactionDetail InsertTransactionDetail(int id, int cardId, int quantity)
        {
            TransactionDetail td = new TransactionDetail();
            td.TransactionID = id;
            td.CardID = cardId;
            td.Quantity = quantity;
            return td;
        }
    }
}