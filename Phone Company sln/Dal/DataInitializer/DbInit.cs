using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.DataInitializer
{
    internal class DbInit : DropCreateDatabaseAlways<PhoneCompanyContext>
    {
        protected override void Seed(PhoneCompanyContext context)
        {
            base.Seed(context);
        }
    }
}
