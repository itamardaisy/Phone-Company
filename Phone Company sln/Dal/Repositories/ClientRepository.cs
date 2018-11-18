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
            using(PhoneCompanyContext context = new PhoneCompanyContext())
            {
                context.Clients.Add(client.CommonToDb());
                context.SaveChanges();
            }
        }

        public Client GetClientById(int id)
        {
            using(PhoneCompanyContext context = new PhoneCompanyContext())
            {
                return context.Clients.FirstOrDefault(x => x.Id == id).DbToCommon();
            }
        }

        public void UpdateClient(Client client)
        {
            using(PhoneCompanyContext context = new PhoneCompanyContext())
            {
                var dbClient = context.Clients.FirstOrDefault(x => x.Id == client.Id);
                UpdateTheClientProperties(dbClient, client);
                context.SaveChanges();
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
