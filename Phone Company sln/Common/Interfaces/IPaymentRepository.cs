using Common.Enums;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IPaymentRepository
    {
        Dictionary<PaymentType, Payment> GetByMonth(DateTime dateTime, Client client, string lineNumber);

        void AddPayment(Payment payment);
    }
}
