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

        public Payment GetByMonth(DateTime dateTime)
        {
            using(PhoneCompanyContext context = new PhoneCompanyContext())
            {
                return context.Payments.Where(x => x.Month.Month == dateTime.Month).FirstOrDefault().DbToCommon();
            }
        }
    }
}
