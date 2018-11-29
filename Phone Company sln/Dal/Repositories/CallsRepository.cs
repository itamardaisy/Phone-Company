using Common.EnvironmentService;
using Common.Exceptions;
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
                try{
                    context.Calls.Add(call.CommonToDb());
                    context.SaveChanges();
                }
                catch(Exception ex){
                    Services.WriteExceptionsToLogger(ex);
                    throw new DataProcedureException(ex.Message);
                }
            }
        }

        public List<Call> GetLineCalls(string lineNumber)
        {
            using (PhoneCompanyContext context = new PhoneCompanyContext())
            {
                try{
                    return context.Calls
                                  .Where(x => x.Line.Number == lineNumber)
                                  .Select(c => c.DbToCommon()).ToList();
                }
                catch(ArgumentNullException ex){
                    Services.WriteExceptionsToLogger(ex);
                    throw new GetFromDatabaseException(ex.Message);
                }
                catch(Exception ex){
                    Services.WriteExceptionsToLogger(ex);
                    throw new DataProcedureException(ex.Message);
                }
            }
        }

        public List<Call> GetLineCallsMonth(string lineNumber)
        {
            using (PhoneCompanyContext context = new PhoneCompanyContext())
            {
                try{
                    DateTime monthAgo = DateTime.Now - TimeSpan.FromDays(30);
                    return context.Calls
                                  .Where(x => x.Line.Number == lineNumber && x.CallDate > monthAgo)
                                  .Select(c => c.DbToCommon()).ToList();
                }
                catch (ArgumentNullException ex){
                    Services.WriteExceptionsToLogger(ex);
                    throw new GetFromDatabaseException(ex.Message);
                }
                catch (Exception ex){
                    Services.WriteExceptionsToLogger(ex);
                    throw new DataProcedureException(ex.Message);
                }
            }
        }
    }
}