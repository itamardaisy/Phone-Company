﻿using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces.BillingService_interfaces
{
    public interface IPaymentCalculator
    {
        Dictionary<string, Receipt> GetTotalClientPayment(int clientId, DateTime date);
    }
}
