using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class SMS
    {
        private int id;
        private double externalPrice;
        private string destinationNumber;
        private DateTime smsDate;
        private int lineId;
        private bool selectedNumberCall;
        private bool familyCall;

        public bool FamilyCall
        {
            get { return familyCall; }
            set { familyCall = value; }
        }

        public bool SelectedNumberCall
        {
            get { return selectedNumberCall; }
            set { selectedNumberCall = value; }
        }

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

        public double ExternalPrice
        {
            get { return externalPrice; }
            set { externalPrice = value; }
        }

        public DateTime SMSDate
        {
            get { return smsDate; }
            set { smsDate = value; }
        }

        public int LineId
        {
            get { return lineId; }
            set { lineId = value; }
        }
    }
}
