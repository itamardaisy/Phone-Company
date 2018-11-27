using Common.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces.BillingService_interfaces
{
    public interface IPaymentDataAccess
    {
        ICollection<Payment> GetClientMonthPayment(int clientId, DateTime month);

        void SaveFileToDatabase(File pdfFile);

        byte[] GetPdfFileFromDataBaseAsByteArray();
    }
}
