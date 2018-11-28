using Common.Exceptions;
using Common.Interfaces;
using Common.Models;
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

        public EmploeeService()
        {
            CR = new ClientRepository();
        }

        public void AddNewClient(Client client)
        {
            try{
                CR.AddNewClient(client);
            }
            catch (AddToDatabaseException ex){
                Common.EnvironmentService.Services.WriteExceptionsToLogger(ex);
            }
            catch(RemoveFromDatabaseException ex){
                Common.EnvironmentService.Services.WriteExceptionsToLogger(ex);
            }
            catch (GetFromDatabaseException ex){
                Common.EnvironmentService.Services.WriteExceptionsToLogger(ex);
            }
        }   

        public bool DeleteClient(int id)
        {
            try{
                return CR.DeleteClient(id);
            }
            catch (AddToDatabaseException ex){
                Common.EnvironmentService.Services.WriteExceptionsToLogger(ex);
            }   
            catch (RemoveFromDatabaseException ex){
                Common.EnvironmentService.Services.WriteExceptionsToLogger(ex);
            }
            catch (GetFromDatabaseException ex){
                Common.EnvironmentService.Services.WriteExceptionsToLogger(ex);
            }
            return false;
        }

        public Package FindOptimizePackage(Client client)
        {
            throw new NotImplementedException();
        }

        public Client GetClient(string lineNumber, string clientName)
        {
            throw new NotImplementedException();
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