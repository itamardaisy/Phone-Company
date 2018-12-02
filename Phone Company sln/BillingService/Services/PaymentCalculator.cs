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

        public Dictionary<string, double> GetTotalClientPayment(int clientId)
        {
            List<Line> clientLins = PDA.GetClientLines(clientId);
            Dictionary<string, double> TotalLinePrice = new Dictionary<string, double>();
            double overLinitPrice = 0.0, basePrice, total;
            foreach (var line in clientLins)
            {
                overLinitPrice = PDA.CalcOverCallLimitPrice(line, DateTime.Now, clientId);
                overLinitPrice += PDA.CalcOverSMSsLimitPrice(line, DateTime.Now, clientId);
                basePrice = PDA.GetBasePackagePrice(line);
                total = basePrice + overLinitPrice;
                TotalLinePrice.Add(line.Number, total);
            }
            return TotalLinePrice;
        }
    }
}
