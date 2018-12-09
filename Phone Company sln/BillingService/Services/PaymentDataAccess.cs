using Common.Interfaces.BillingService_interfaces;
using Common.Models;
using Dal.DataInitializer;
using Dal.Repositories;
using System;
using System.Collections.Generic;

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
            LINE_REPOSITORY = new LineRepository();
            PAYMENT_REPOSITORY = new PaymentRepository();
            PACKAGE_REPOSITORY = new PackageRepository();
            CLIENT_REPOSITORY = new ClientRepository();
        }

        internal Receipt SetLineReceipt(Line line, DateTime date, int clientId)
        {
            Receipt receipt = new Receipt();
            receipt.BasePrice = PACKAGE_REPOSITORY.GetBasePrice(line.Id);
            receipt.CallsExtraPrice = CalcOverCallLimitPrice(line, date, clientId);
            receipt.SMSsExtraPrice = CalcOverSMSsLimitPrice(line, date, clientId);
            receipt.DisscountPercentage = PACKAGE_REPOSITORY.GetPackagePercentage(line.PackageId);
            return receipt;
        }

        private double CalcOverSMSsLimitPrice(Line line, DateTime date, int clientId)
        {
            int clientTypeId = CLIENT_REPOSITORY.GetClientById(clientId).ClientTypeId;
            int overLimitSMSs = 0;
            int SMSsInPackage = PACKAGE_REPOSITORY.GetSMSsInPackage(line.Id);
            int actualySMSs = LINE_REPOSITORY.GetActualMonthSMSs(line.Id, date);
            if (actualySMSs > SMSsInPackage)
                overLimitSMSs = actualySMSs - SMSsInPackage;
            return PAYMENT_REPOSITORY.CalcOverLimitCallsPayment(overLimitSMSs, clientTypeId);
        }

        private double CalcOverCallLimitPrice(Line line,DateTime date, int clientId)
        {
            int clientTypeId = CLIENT_REPOSITORY.GetClientById(clientId).ClientTypeId;
            double overLimitMinuts = 0.0;
            double minutsInPackage = (double)PACKAGE_REPOSITORY.GetMinutsInPackage(line.Id);
            double actualyMinuts = LINE_REPOSITORY.GetActualMonthMinuteCalls(line.Id, date);
            if (actualyMinuts > minutsInPackage)
                overLimitMinuts = actualyMinuts - minutsInPackage;
            return PAYMENT_REPOSITORY.CalcOverLimitCallsPayment(overLimitMinuts, clientTypeId);
        }

        internal List<Line> GetClientLines(int clientId)
        {
            return LINE_REPOSITORY.GetClientLines(clientId);
        }
    }
}