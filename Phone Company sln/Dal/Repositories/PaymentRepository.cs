using Common.Enums;
using Common.Interfaces;
using Common.Models;
using Dal.DataInitializer;
using Dal.ModelConverters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        public void AddPayment(Payment payment)
        {
            using(PhoneCompanyContext context = new PhoneCompanyContext())
            {
                context.Payments.Add(payment.CommonToDb());
                context.SaveChanges();
            }
        }

        public Dictionary<PaymentType,Payment> GetByMonth(DateTime dateTime, Client client, string lineNumber)
        {
            using(PhoneCompanyContext context = new PhoneCompanyContext())
            {
                var calls = context.Calls.Select(x => x.CallDate.Month == dateTime.Month).ToList();
                var smss = context.SMSs.Select(x => x.SMSDate.Month == dateTime.Month).ToList();
                foreach
            }
        }
    }
}