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
        private readonly IClientRepository _clientRepository;
        private readonly IClientTypeRepository _clientTypeRepository;

        public EmploeeService(IClientRepository clientRepository, IClientTypeRepository clientTypeRepository)
        {
            _clientRepository = clientRepository;
            _clientTypeRepository = clientTypeRepository;
        }

        public void AddNewClient(Client client)
        {
            try
            {
                _clientRepository.AddNewClient(client);
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
                return _clientRepository.DeleteClient(id);
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
            //TODO: Find optimal package in BL Employee Service
            throw new NotImplementedException();
        }

        public Client GetClient(int clientID)
        {
            return _clientRepository.GetClientById(clientID);
        }

        public List<ClientType> GetClientTypes()
        {
            return _clientTypeRepository.GetAllTypes();
        }

        public void UpdateClientDetails(Client client)
        {
            _clientRepository.UpdateClient(client);
        }
    }
}