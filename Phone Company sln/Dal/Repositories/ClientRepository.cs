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
        PhoneCompanyContext context;

        public ClientRepository(PhoneCompanyContext context)
        {
            this.context = context;
        }

        public Client LoginClient(string name, int clientId)
        {
            return context.Clients.FirstOrDefault(x => x.Id == clientId && x.Name == name).DbToCommon();
        }

        /// <summary>
        /// This method gets a client from the BL and add it to the context.
        /// </summary>
        /// <param name="client"> The client from the BL </param>
        public void AddNewClient(Client client)
        {
            try
            {
                context.Clients.Add(client.CommonToDb());
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Services.WriteExceptionsToLogger(ex);
                throw new DataProcedureException(ex.Message);
            }
        }

        /// <summary>
        /// This method gets the id of the wanted client and remove him from the context.
        /// </summary>
        /// <param name="id"> The Id of the client </param> 
        /// <returns> True if the client removed seccesfully, otherwise false </returns>
        public bool DeleteClient(int id)
        {
            try
            {
                var clientToRemove = context.Clients.FirstOrDefault(x => x.Id == id);
                context.UnsignClients.Add(FromClientToUnsignClient(clientToRemove));
                context.Clients.Remove(clientToRemove);
                context.SaveChanges();
                if (context.Clients.Any(x => x.Id == id))
                    return false;
                else
                    return true;
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
        /// This h=method gets client and convert it to UnsignClient
        /// </summary>
        /// <param name="client"> The wanted client </param>
        /// <returns> The unsign client </returns>
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

        /// <summary>
        /// This method gets an id and to fine the wanted client.
        /// </summary>
        /// <param name="id"> The client Id </param>
        /// <returns> The wanted client </returns>
        public Client GetClientById(int id)
        {
            try
            {
                return context.Clients.FirstOrDefault(x => x.Id == id).DbToCommon();
            }
            catch (ArgumentNullException ex)
            {
                Services.WriteExceptionsToLogger(ex);
                throw new GetFromDatabaseException(ex.Message);
            }
        }

        /// <summary>
        /// This method gets a full client and compare him with the wanted client to update.
        /// </summary>
        /// <param name="client"> The client to update </param>
        public void UpdateClient(Client client)
        {
            try
            {
                var dbClient = context.Clients.FirstOrDefault(x => x.Id == client.Id);
                UpdateTheClientProperties(dbClient, client);
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
        /// This method doing the actualy updating to the specific client.
        /// </summary>
        /// <param name="dbClient"> the db client </param>
        /// <param name="client"> the common client that holds the updated properties</param>
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
