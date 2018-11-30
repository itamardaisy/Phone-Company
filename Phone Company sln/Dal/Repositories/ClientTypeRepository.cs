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
        PhoneCompanyContext context;

        public ClientTypeRepository(PhoneCompanyContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// This method gets a new client type and add it to the context.
        /// </summary>
        /// <param name="clientType"> The new client type </param>
        public void AddNewType(ClientType clientType)
        {
            try
            {
                context.ClientTypes.Add(clientType.CommonToDb());
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Services.WriteExceptionsToLogger(ex);
                throw new DataProcedureException(ex.Message);
            }
        }

        /// <summary>
        /// This method get a client type name and delete it from the context.
        /// </summary>
        /// <param name="typeName"> The type name </param>
        /// <returns> True if the type has removed, otherwise false </returns>
        public bool DeleteType(string typeName)
        {
            try
            {
                context.ClientTypes.Remove(context.ClientTypes.FirstOrDefault(x => x.TypeName == typeName));
                if (!(context.ClientTypes.Any(x => x.TypeName == typeName)))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                Services.WriteExceptionsToLogger(ex);
                throw new DataProcedureException(ex.Message);
            }
        }

        /// <summary>
        /// Returns the all client type that exist.
        /// </summary>
        /// <returns> List of client types </returns>
        public List<ClientType> GetAllTypes()
        {
            try
            {
                return context.ClientTypes.Select(x => x.DbToCommon()).ToList();
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

        /// <summary>
        /// Returns a client type by name.
        /// </summary>
        /// <param name="typeName"> The type name </param>
        /// <returns> Client type </returns>
        public ClientType GetTypeByName(string typeName)
        {
            try
            {
                return context.ClientTypes.FirstOrDefault(x => x.TypeName == typeName).DbToCommon();
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

        /// <summary>
        /// This method gets the name of the client type and the new price for minutes
        /// and update the price.
        /// </summary>
        /// <param name="typeName"> The type name </param>
        /// <param name="newPrice"> The new price </param>
        public void UpdateMinutePrice(string typeName, double newPrice)
        {
            try
            {
                context.ClientTypes.FirstOrDefault(x => x.TypeName == typeName)
                                   .MinutePrice = newPrice;
                context.SaveChanges();
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

        /// <summary>
        /// This method gets the name of the client type and the new price for SMS
        /// and update the price.
        /// </summary>
        /// <param name="typeName"> The type name </param>
        /// <param name="newPrice"> The new price </param>
        public void UpdateSMSPrice(string typeName, double newPrice)
        {
            try
            {
                context.ClientTypes.FirstOrDefault(x => x.TypeName == typeName)
                                   .SMSPrice = newPrice;
                context.SaveChanges();
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