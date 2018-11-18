using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class ClientType
    {
        private int id;
        private string typeName;
        private double minutePrice;
        private double smsPrice;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string TypeName
        {
            get { return typeName; }
            set { typeName = value; }
        }

        public double MinutePrice
        {
            get { return minutePrice; }
            set { minutePrice = value; }
        }

        public double SMSPrice
        {
            get { return smsPrice; }
            set { smsPrice = value; }
        }
    }
}
