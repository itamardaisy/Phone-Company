using Windows.System;
using Windows.System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Employee.Models
{
    internal class SMS
    {
        private int id;
        private double externalPrice;
        private int lineId;
        private string destinationNumber;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string DestinationNumber
        {
            get { return destinationNumber; }
            set { destinationNumber = value; }
        }

        public int LineId
        {
            get { return lineId; }
            set { lineId = value; }
        }

        public double ExternalPrice
        {
            get { return externalPrice; }
            set { externalPrice = value; }
        }
    }
}