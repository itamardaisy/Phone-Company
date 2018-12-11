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
        private readonly LineRepository _lineRepository;
        private readonly PackageRepository _packageRepository;
        private readonly PaymentRepository _paymentRepository;
        private readonly ClientRepository _clientRepository;

        public PaymentDataAccess()
        {
            _lineRepository = new LineRepository();
            _paymentRepository = new PaymentRepository();
            _packageRepository = new PackageRepository();
            _clientRepository = new ClientRepository();
        }

        internal Receipt SetLineReceipt(Line line, DateTime date, int clientId)
        {
            Receipt receipt = new Receipt();
            receipt.BasePrice = _packageRepository.GetBasePrice(line.Id);
            receipt.CallsExtraPrice = CalcOverCallLimitPrice(line, date, clientId);
            receipt.SMSsExtraPrice = CalcOverSMSsLimitPrice(line, date, clientId);
            receipt.DisscountPercentage = _packageRepository.GetPackagePercentage(line.PackageId);
            return receipt;
        }

        private double CalcOverSMSsLimitPrice(Line line, DateTime date, int clientId)
        {
            int clientTypeId = _clientRepository.GetClientById(clientId).ClientTypeId;
            int overLimitSMSs = 0;
            int SMSsInPackage = _packageRepository.GetSMSsInPackage(line.Id);
            int actualySMSs = _lineRepository.GetActualMonthSMSs(line.Id, date);
            if (actualySMSs > SMSsInPackage)
                overLimitSMSs = actualySMSs - SMSsInPackage;
            return _paymentRepository.CalcOverLimitCallsPayment(overLimitSMSs, clientTypeId);
        }

        private double CalcOverCallLimitPrice(Line line,DateTime date, int clientId)
        {
            int clientTypeId = _clientRepository.GetClientById(clientId).ClientTypeId;
            double overLimitMinuts = 0.0;
            double minutsInPackage = (double)_packageRepository.GetMinutsInPackage(line.Id);
            double actualyMinuts = _lineRepository.GetActualMonthMinuteCalls(line.Id, date);
            if (actualyMinuts > minutsInPackage)
                overLimitMinuts = actualyMinuts - minutsInPackage;
            return _paymentRepository.CalcOverLimitCallsPayment(overLimitMinuts, clientTypeId);
        }

        internal List<Line> GetClientLines(int clientId)
        {
            return _lineRepository.GetClientLines(clientId);
        }
    }
}