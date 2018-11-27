using Common.Interfaces.BillingService_interfaces;
using Common.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingService.Services
{
    public class PaymentDataAccess : IPaymentDataAccess
    {
        public ICollection<Payment> GetClientMonthPayment(int clientId, DateTime month)
        {
            throw new NotImplementedException();
        }

        public byte[] GetPdfFileFromDataBaseAsByteArray()
        {
            throw new NotImplementedException();
        }

        public void SaveFileToDatabase(string pdf)
        {
            throw new NotImplementedException();
        }
    }
}