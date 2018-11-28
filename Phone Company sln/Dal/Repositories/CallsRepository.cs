using Common.Interfaces;
using Common.Models;
using Dal.DataInitializer;
using Dal.DataModels;
using Dal.ModelConverters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Repositories
{
    public class CallsRepository : ICallsRepository
    {
        public void AddNewCall(Call call)
        {
            using (PhoneCompanyContext context = new PhoneCompanyContext())
            {
                context.Calls.Add(call.CommonToDb());
                context.SaveChanges();
            }
        }

        public List<Call> GetLineCalls(string lineNumber)
        {
            using (PhoneCompanyContext context = new PhoneCompanyContext())
            {
                return context.Calls
                              .Where(x => x.Line == lineNumber)
                              .Select(c => c.DbToCommon()).ToList();
            }
        }

        public List<Call> GetLineCallsMonth(string lineNumber)
        {
            using (PhoneCompanyContext context = new PhoneCompanyContext())
            {
                DateTime monthAgo = DateTime.Now - TimeSpan.FromDays(30);
                return context.Calls
                              .Where(x => x.Line == lineNumber && x.CallDate > monthAgo)
                              .Select(c => c.DbToCommon()).ToList();
            }
        }
    }
}