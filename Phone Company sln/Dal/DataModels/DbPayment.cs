using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.DataModels
{
    public class DbPayment
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        public DateTime Month { get; set; }

        public double TotalPayment { get; set; }
    }
}
