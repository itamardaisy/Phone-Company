using Common.Enums;
using Common.EnvironmentService;
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
        private PhoneCompanyContext context;

        public PaymentRepository(PhoneCompanyContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// This method gets a new payment and add it to the context.
        /// </summary>
        /// <param name="payment"> </param>
        public void AddPayment(Payment payment)
        {
            try
            {
                context.Payments.Add(payment.CommonToDb());
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Services.WriteExceptionsToLogger(ex);
            }
        }

        public Dictionary<PaymentType, Payment> GetByMonth(DateTime dateTime, Client client, string lineNumber)
        {
            var calls = context.Calls.Select(x => x.CallDate.Month == dateTime.Month).ToList();
            var smss = context.SMSs.Select(x => x.SMSDate.Month == dateTime.Month).ToList();
            return null;
        }

        public double CalcOverLimitCallsPayment(double overLimitMinuts, int clientTypeId)
        {
            var clientType = context.ClientTypes.FirstOrDefault(x => x.Id == clientTypeId);
            return overLimitMinuts * clientType.MinutePrice;
        }

        public double CalcOverLimitSMSsPayment(int overLimitSMSs, int clientTypeId)
        {
            var clientType = context.ClientTypes.FirstOrDefault(x => x.Id == clientTypeId);
            return overLimitSMSs * clientType.SMSPrice;
        }

        public double GetPackagePaymentByLine(int lineId)
        {
            throw new NotImplementedException();
        }
    }
}