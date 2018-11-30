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
    public class ManagerRepository : IManagerRepository
    {
        PhoneCompanyContext context;

        public ManagerRepository(PhoneCompanyContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// This method gets the wanted client id and query from the data base his line.
        /// after this it take the all payment on the lines and returns them in list.
        /// </summary>
        /// <param name="clientId"> The wanted client </param>
        /// <returns> List of payments </returns>
        public List<Payment> GetClientReport(int clientId)
        {
            try
            {
                var clientLines = context.Lines.Where(x => x.ClientId == clientId).ToList();
                List<Payment> clientPayments = new List<Payment>();
                for (int i = 0; i < clientLines.Count; i++)
                    clientPayments.Add(context.Payments.FirstOrDefault(x => x.LineId == clientLines[i].Id).DbToCommon());
                return clientPayments;
            }
            catch (Exception ex)
            {

            }
        }

        public List<Client> GetClientWhoMostLikleyToUnsign()
        {
            throw new NotImplementedException();
        }

        public Client GetMostAnoyingClient()
        {
            throw new NotImplementedException();
        }

        public List<Client> GetMostConectedClients()
        {
            throw new NotImplementedException();
        }

        public Client GetMostProftableClient()
        {
            throw new NotImplementedException();
        }

        public User GetMostvalentEmployee()
        {
            throw new NotImplementedException();
        }
    }
}
