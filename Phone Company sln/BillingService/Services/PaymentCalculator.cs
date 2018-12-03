using Common.Interfaces.BillingService_interfaces;
using Common.Models;
using Dal.DataInitializer;
using Dal.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingService.Services
{
    public class PaymentCalculator : IPaymentCalculator
    {
        private readonly PaymentDataAccess PDA;

        public PaymentCalculator()
        {
            PDA = new PaymentDataAccess();
        }

        public Dictionary<string, Receipt> GetTotalClientPayment(int clientId, DateTime date)
        {
            List<Line> clientLins = PDA.GetClientLines(clientId);
            Dictionary<string, Receipt> TotalLinePrice = new Dictionary<string, Receipt>();
            foreach (var line in clientLins)
                TotalLinePrice.Add(line.Number, PDA.SetLineReceipt(line, date, clientId));
            return TotalLinePrice;
        }
    }
}
