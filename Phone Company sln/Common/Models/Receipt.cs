using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class Receipt
    {
        private double basePrice;
        private double sMSsExtraPrice;
        private double callsExtraPrice;
        private int disscountPercentage;
        private double totalPriceBeforeDisscount;
        private double totalPriceAfterDisscount;

        public double BasePrice
        {
            get { return basePrice; }
            set { basePrice = value; }
        }

        public double TotalPriceAfterDisscount
        {
            get { return totalPriceAfterDisscount; }
            private set
            {
                totalPriceAfterDisscount = totalPriceBeforeDisscount - ((disscountPercentage / 100) * totalPriceBeforeDisscount);
            }
        }

        public double TotalPriceBeforeDisscount
        {
            get { return totalPriceBeforeDisscount; }
            private set
            {
                totalPriceBeforeDisscount = basePrice + sMSsExtraPrice + callsExtraPrice;
            }
        }

        public int DisscountPercentage
        {
            get { return disscountPercentage; }
            set { disscountPercentage = value; }
        }

        public double CallsExtraPrice
        {
            get { return callsExtraPrice; }
            set { callsExtraPrice = value; }
        }

        public double SMSsExtraPrice
        {
            get { return sMSsExtraPrice; }
            set { sMSsExtraPrice = value; }
        }
    }
}
