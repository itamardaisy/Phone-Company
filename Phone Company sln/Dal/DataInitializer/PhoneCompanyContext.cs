using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.DataInitializer
{
    public class PhoneCompanyContext : DbContext
    {
        public PhoneCompanyContext()
        {
            Database.SetInitializer(new DbInit());
        }
    }
}
