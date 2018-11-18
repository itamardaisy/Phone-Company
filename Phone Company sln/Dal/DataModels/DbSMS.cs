using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.DataModels
{
    public class DbSMS
    {
        public int Id { get; set; }

        public double ExternalPrice { get; set; }

        public int LineId { get; set; }

        public string DestinationNumber { get; set; }
    }
}
