using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class Payment
    {
        private int id;
        private DateTime month;
        private double totalPayment;
        private int clientId;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public DateTime Month
        {
            get { return month; }
            set { month = value; }
        }

        public double TotalPayment
        {
            get { return totalPayment; }
            set { totalPayment = value; }
        }

        public int ClientId
        {
            get { return clientId; }
            set { clientId = value; }
        }
    }
}
