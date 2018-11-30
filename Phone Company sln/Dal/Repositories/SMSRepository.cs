using Common.Interfaces;
using Common.Models;
using Dal.DataInitializer;
using Dal.ModelConverters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Repositories
{
    public class SMSRepository : ISMSRepository
    {
        PhoneCompanyContext context;

        public SMSRepository(PhoneCompanyContext context)
        {
            this.context = context;
        }

        public void AddNewSMS(SMS sMS)
        {
            context.SMSs.Add(sMS.CommonToDb());
            context.SaveChanges();
        }

        public List<SMS> GetLineSMS(string lineNumber)
        {
            var DbSmss = context.SMSs.Where(x => x.Line.Number == lineNumber).ToList();
            List<SMS> CommonSmss = new List<SMS>();
            foreach (var item in DbSmss)
                CommonSmss.Add(item.DbToCommon());
            return CommonSmss;
        }

        public List<SMS> GetLineSMSMonth(string lineNumber)
        {
            DateTime monthAgo = DateTime.Now.AddMonths(-1);
            var DbSmss = context.SMSs.Where(x => x.Line.Number == lineNumber && x.SmsDate > monthAgo).ToList();
            List<SMS> CommonSmss = new List<SMS>();
            foreach (var item in DbSmss)
                CommonSmss.Add(item.DbToCommon());
            return CommonSmss;
        }
    }
}
