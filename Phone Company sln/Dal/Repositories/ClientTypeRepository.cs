using Common.Interfaces;
using Common.Models;
using Dal.DataInitializer;
using System;
using System.Collections.Generic;
using Dal.ModelConverters;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.DataModels;
using Common.EnvironmentService;
using Common.Exceptions;

namespace Dal.Repositories
{
    public class ClientTypeRepository : IClientTypeRepository
    {
        public void AddNewType(ClientType clientType)
        {
            using (PhoneCompanyContext context = new PhoneCompanyContext())
            {
                try{
                    context.ClientTypes.Add(clientType.CommonToDb());
                    context.SaveChanges();
                }
                catch (Exception ex){
                    Services.WriteExceptionsToLogger(ex);
                    throw new DataProcedureException(ex.Message);
                }
            }
        }

        public bool DeleteType(string typeName)
        {
            using (PhoneCompanyContext context = new PhoneCompanyContext())
            {
                try{
                    context.ClientTypes.Remove(context.ClientTypes.FirstOrDefault(x => x.TypeName == typeName));
                    if (!(context.ClientTypes.Any(x => x.TypeName == typeName)))
                        return true;
                    else
                        return false;
                }
                catch (Exception ex){
                    Services.WriteExceptionsToLogger(ex);
                    throw new DataProcedureException(ex.Message);
                }
            }
        }

        public List<ClientType> GetAllTypes()
        {
            using (PhoneCompanyContext context = new PhoneCompanyContext())
            {
                try{
                    return context.ClientTypes.Select(x => x.DbToCommon()).ToList();
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

        public ClientType GetTypeByName(string typeName)
        {
            using (PhoneCompanyContext context = new PhoneCompanyContext())
            {
                try{
                    return context.ClientTypes.FirstOrDefault(x => x.TypeName == typeName).DbToCommon();
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

        public void UpdateMinutePrice(string typeName, double newPrice)
        {
            using (PhoneCompanyContext context = new PhoneCompanyContext())
            {
                try{
                    context.ClientTypes.FirstOrDefault(x => x.TypeName == typeName)
                                       .MinutePrice = newPrice;
                    context.SaveChanges();
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

        public void UpdateSMSPrice(string typeName, double newPrice)
        {
            using (PhoneCompanyContext context = new PhoneCompanyContext())
            {
                try{
                    context.ClientTypes.FirstOrDefault(x => x.TypeName == typeName)
                                       .SMSPrice = newPrice;
                    context.SaveChanges();
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