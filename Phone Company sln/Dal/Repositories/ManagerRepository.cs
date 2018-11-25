using Common.Interfaces;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Repositories
{
    public class ManagerRepository : IManagerRepository
    {
        
        public Line GetClientReport(Line line)
        {
            throw new NotImplementedException();
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
