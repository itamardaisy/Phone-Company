using Common.Exceptions;
using Common.Interfaces;
using Common.Models;
using Dal.DataInitializer;
using Dal.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class EmploeeService : IEmploeeService
    {
        private readonly ClientRepository CR;
        private readonly ClientTypeRepository CTR;
        private readonly PhoneCompanyContext CONTEXT;

        public EmploeeService()
        {
            CONTEXT = new PhoneCompanyContext();
            CR = new ClientRepository(CONTEXT);
            CTR = new ClientTypeRepository(CONTEXT);
        }

        public void AddNewClient(Client client)
        {
            try
            {
                CR.AddNewClient(client);
            }
            catch (AddToDatabaseException ex)
            {
                Common.EnvironmentService.Services.WriteExceptionsToLogger(ex);
            }
            catch (RemoveFromDatabaseException ex)
            {
                Common.EnvironmentService.Services.WriteExceptionsToLogger(ex);
            }
            catch (GetFromDatabaseException ex)
            {
                Common.EnvironmentService.Services.WriteExceptionsToLogger(ex);
            }
        }

        public bool DeleteClient(int id)
        {
            try
            {
                return CR.DeleteClient(id);
            }
            catch (GetFromDatabaseException ex)
            {
                Common.EnvironmentService.Services.WriteExceptionsToLogger(ex);
            }
            catch (DataProcedureException ex)
            {
                Common.EnvironmentService.Services.WriteExceptionsToLogger(ex);
            }
            return false;
        }

        public Package FindOptimizePackage(Client client)
        {
            throw new NotImplementedException();
        }

        public Client GetClient(int clientID)
        {
            return CR.GetClientById(clientID);
        }

        public List<ClientType> GetClientTypes()
        {
            throw new NotImplementedException();
        }

        public Receipt GetReceiptByMonth(int clientId, DateTime month)
        {
            throw new NotImplementedException();
        }

        public void UpdateClientDetails(Client client)
        {
            throw new NotImplementedException();
        }
    }
}