using Common.Interfaces;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        public bool AddPayment(Payment payment)
        {
            throw new NotImplementedException();
        }

        public Payment GetByMonth(DateTime dateTime)
        {
            throw new NotImplementedException();
        }
    }
}
