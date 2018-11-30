using Common.EnvironmentService;
using Common.Exceptions;
using Common.Interfaces;
using Common.Models;
using Dal.DataInitializer;
using Dal.ModelConverters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dal.Repositories
{
    public class CallsRepository : ICallsRepository
    {
        PhoneCompanyContext context;

        public CallsRepository(PhoneCompanyContext context)
        {
            this.context = context;
        }

        public void AddNewCall(Call call)
        {
            try
            {
                context.Calls.Add(call.CommonToDb());
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Services.WriteExceptionsToLogger(ex);
                throw new DataProcedureException(ex.Message);
            }
        }

        public List<Call> GetLineCalls(string lineNumber)
        {
            try
            {
                return context.Calls
                              .Where(x => x.Line.Number == lineNumber)
                              .Select(c => c.DbToCommon()).ToList();
            }
            catch (ArgumentNullException ex)
            {
                Services.WriteExceptionsToLogger(ex);
                throw new GetFromDatabaseException(ex.Message);
            }
            catch (Exception ex)
            {
                Services.WriteExceptionsToLogger(ex);
                throw new DataProcedureException(ex.Message);
            }
        }

        public List<Call> GetLineCallsMonth(string lineNumber)
        {
            try
            {
                DateTime monthAgo = DateTime.Now - TimeSpan.FromDays(30);
                return context.Calls
                              .Where(x => x.Line.Number == lineNumber && x.CallDate > monthAgo)
                              .Select(c => c.DbToCommon()).ToList();
            }
            catch (ArgumentNullException ex)
            {
                Services.WriteExceptionsToLogger(ex);
                throw new GetFromDatabaseException(ex.Message);
            }
            catch (Exception ex)
            {
                Services.WriteExceptionsToLogger(ex);
                throw new DataProcedureException(ex.Message);
            }
        }
    }
}