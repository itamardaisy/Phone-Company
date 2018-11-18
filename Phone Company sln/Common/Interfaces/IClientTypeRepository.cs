using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IClientTypeRepository
    {
        ClientType GetTypeByName(string typeName);

        void AddNewType(ClientType clientType);

        bool DeleteType(string typeName);

        List<ClientType> GetAllTypes();

        void UpdateMinutePrice(string typeName, double newPrice);

        void UpdateSMSPrice(string typeName, double newPrice);
    }
}
