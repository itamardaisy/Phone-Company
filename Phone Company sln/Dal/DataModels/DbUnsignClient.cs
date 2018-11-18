using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.DataModels
{
    public class DbUnsignClient
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public int ClientTypeId { get; set; }

        public string Adress { get; set; }

        public string ContactNumber { get; set; }

        public DateTime SignDate { get; set; }

        public DateTime UnsignDate { get; set; }

        public int CallToCenter { get; set; }
    }
}
