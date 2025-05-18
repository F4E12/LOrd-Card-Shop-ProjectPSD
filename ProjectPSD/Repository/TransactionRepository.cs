using ProjectPSD.Factory;
using ProjectPSD.Models;
using System;
using System.Collections.Generic;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Web;

namespace ProjectPSD.Repository
{
    public class TransactionRepository
    {
        protected static CardShopEntities db = new CardShopEntities();

        public static TransactionHeader InsertTransactionHeader(int id, DateTime transactionDate, int customerId, string status)
        {
            TransactionHeader th = TransactionFactory.InsertTransactionHeader(id, transactionDate, customerId, status);
            db.TransactionHeaders.Add(th);
            db.SaveChanges();
            return th;
        }
        
        public static void InsertTransactionDetail(int id, int cardId, int quantity)
        {
            TransactionDetail td = TransactionFactory.InsertTransactionDetail(id, cardId, quantity);
            db.TransactionDetails.Add(td);
            db.SaveChanges();
        }

        public static TransactionDetail GetLastTransactionDetail()
        {
            return db.TransactionDetails.ToList().LastOrDefault();
        }
        public static TransactionHeader GetLastTransactionHeader()
        {
            return db.TransactionHeaders.ToList().LastOrDefault();
        }

        public static List<TransactionHeader> GetAllTransactionHeader()
        {
            return db.TransactionHeaders.ToList();
        }
        
        public static List<TransactionDetail> GetAllTransactionDetail()
        {
            return db.TransactionDetails.ToList();
        }

        public static TransactionHeader GetTransactionHeader(int transId)
        {
            return db.TransactionHeaders.Find(transId);
        }

        public static void UpdateTransactionHeaderStatus(int transId, string status)
        {
            TransactionHeader th = db.TransactionHeaders.Find(transId);
            th.Status = status;
            db.SaveChanges();
        }
        public static List<TransactionHeader> GetTransactionHeaderByUserId(int userId)
        {
            return db.TransactionHeaders.Where(th => th.CustomerID == userId).ToList();
        }

    }
}