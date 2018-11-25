using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class Call
    {
        private int id;
        private double duration;
        private string destinationNumber;
        private DateTime callDate;
        private int lineId;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public DateTime CallDate
        {
            get { return callDate; }
            set { callDate = value; }
        }

        public int LineId
        {
            get { return lineId; }
            set { lineId = value; }
        }

        public double Duration
        {
            get { return duration; }
            set { duration = value; }
        }

        public string DestinationNumber
        {
            get { return destinationNumber; }
            set { destinationNumber = value; }
        }
    }
}
