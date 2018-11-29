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
    public class ClientRepository : IClientRepository
    {
        public void AddNewClient(Client client)
        {
            using (PhoneCompanyContext context = new PhoneCompanyContext())
            {
                try{
                    context.Clients.Add(client.CommonToDb());
                    context.SaveChanges();
                }
                catch (Exception ex){
                    Services.WriteExceptionsToLogger(ex);
                    throw new DataProcedureException(ex.Message);
                }
            }
        }

        public bool DeleteClient(int id)
        {
            using (PhoneCompanyContext context = new PhoneCompanyContext())
            {
                try{
                    var clientToRemove = context.Clients.FirstOrDefault(x => x.Id == id);
                    context.UnsignClients.Add(FromClientToUnsignClient(clientToRemove));
                    context.Clients.Remove(clientToRemove);
                    context.SaveChanges();
                    if (context.Clients.Any(x => x.Id == id))
                        return false;
                    else
                        return true;
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

        private DbUnsignClient FromClientToUnsignClient(DbClient client)
        {
            return new DbUnsignClient()
            {
                Name = client.Name,
                LastName = client.LastName,
                SignDate = client.SignDate,
                UnsignDate = DateTime.Now,
                Adress = client.Adress,
                CallToCenter = client.CallToCenter,
                ClientTypeId = client.ClientTypeId,
                ContactNumber = client.ContactNumber,
                UserId = client.UserId
            };
        }

        public Client GetClientById(int id)
        {
            using (PhoneCompanyContext context = new PhoneCompanyContext())
            {
                try{
                    return context.Clients.FirstOrDefault(x => x.Id == id).DbToCommon();
                }
                catch(ArgumentNullException ex){
                    Services.WriteExceptionsToLogger(ex);
                    throw new GetFromDatabaseException(ex.Message);
                }
            }
        }

        public void UpdateClient(Client client)
        {
            using (PhoneCompanyContext context = new PhoneCompanyContext())
            {
                try{
                    var dbClient = context.Clients.FirstOrDefault(x => x.Id == client.Id);
                    UpdateTheClientProperties(dbClient, client);
                    context.SaveChanges();
                }
                catch (ArgumentNullException ex){
                    Services.WriteExceptionsToLogger(ex);
                    throw new GetFromDatabaseException(ex.Message);
                }
                catch(Exception ex){
                    Services.WriteExceptionsToLogger(ex);
                    throw new DataProcedureException(ex.Message);
                }
            }
        }

        private void UpdateTheClientProperties(DbClient dbClient, Client client)
        {
            dbClient.Adress = client.Adress;
            dbClient.CallToCenter = client.CallToCenter;
            dbClient.ClientTypeId = client.ClientTypeId;
            dbClient.ContactNumber = client.ContactNumber;
            dbClient.Id = client.Id;
            dbClient.LastName = client.LastName;
            dbClient.Name = client.Name;
            dbClient.SignDate = client.SignDate;
        }
    }
}
