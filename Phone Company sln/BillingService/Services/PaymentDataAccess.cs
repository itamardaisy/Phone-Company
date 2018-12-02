using Common.Interfaces.BillingService_interfaces;
using Common.Models;
using Dal.DataInitializer;
using Dal.Repositories;
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
        private readonly LineRepository LINE_REPOSITORY;
        private readonly PackageRepository PACKAGE_REPOSITORY;
        private readonly PaymentRepository PAYMENT_REPOSITORY;
        private readonly ClientRepository CLIENT_REPOSITORY;

        public PaymentDataAccess()
        {
            PhoneCompanyContext context = new PhoneCompanyContext();
            LINE_REPOSITORY = new LineRepository(context);
            PAYMENT_REPOSITORY = new PaymentRepository(context);
            PACKAGE_REPOSITORY = new PackageRepository(context);
            CLIENT_REPOSITORY = new ClientRepository(context);
        }

        internal double CalcOverSMSsLimitPrice(Line line, DateTime date, int clientId)
        {
            int clientTypeId = CLIENT_REPOSITORY.GetClientById(clientId).ClientTypeId;
            int overLimitSMSs = 0;
            int SMSsInPackage = PACKAGE_REPOSITORY.GetSMSsInPackage(line.Id);
            int actualySMSs = LINE_REPOSITORY.GetActualMonthSMSs(line.Id, date);
            if (actualySMSs > SMSsInPackage)
                overLimitSMSs = actualySMSs - SMSsInPackage;
            return PAYMENT_REPOSITORY.CalcOverLimitCallsPayment(overLimitSMSs, clientTypeId);
        }

        internal double CalcOverCallLimitPrice(Line line,DateTime date, int clientId)
        {
            int clientTypeId = CLIENT_REPOSITORY.GetClientById(clientId).ClientTypeId;
            double overLimitMinuts = 0.0;
            double minutsInPackage = (double)PACKAGE_REPOSITORY.GetMinutsInPackage(line.Id);
            double actualyMinuts = LINE_REPOSITORY.GetActualMonthSMSs(line.Id, date);
            if (actualyMinuts > minutsInPackage)
                overLimitMinuts = actualyMinuts - minutsInPackage;
            return PAYMENT_REPOSITORY.CalcOverLimitCallsPayment(overLimitMinuts, clientTypeId);
        }

        internal double GetBasePackagePrice(Line line)
        {
            throw new NotImplementedException();
        }

        internal List<Line> GetClientLines(int clientId)
        {
            return LINE_REPOSITORY.GetClientLines(clientId);
        }
    }
}