using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface ISMSRepository
    {
        void AddNewSMS(SMS sMS);

        List<SMS> GetLineSMS(string lineNumber);

        List<SMS> GetLineSMSMonth(string lineNumber);
    }
}
