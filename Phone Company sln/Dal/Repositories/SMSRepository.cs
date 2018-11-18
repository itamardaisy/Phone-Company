using Common.Interfaces;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Repositories
{
    public class SMSRepository : ISMSRepository
    {
        public Call AddNewSMS(SMS sMS)
        {
            throw new NotImplementedException();
        }

        public List<SMS> GetLineSMS(string lineNumber)
        {
            throw new NotImplementedException();
        }

        public List<SMS> GetLineSMSMonth(string lineNumber)
        {
            throw new NotImplementedException();
        }
    }
}
