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
        Payment GetByMonth(DateTime dateTime);

        void AddPayment(Payment payment);
    }
}
