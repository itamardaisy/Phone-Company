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
        private int lineId;

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

        public int LineId
        {
            get { return lineId; }
            set { lineId = value; }
        }
    }
}
