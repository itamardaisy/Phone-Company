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

namespace Dal.Repositories
{
    public class ClientTypeRepository : IClientTypeRepository
    {
        public void AddNewType(ClientType clientType)
        {
            using (PhoneCompanyContext context = new PhoneCompanyContext())
            {
                context.ClientTypes.Add(clientType.CommonToDb());
                context.SaveChanges();

            }
        }

        public bool DeleteType(string typeName)
        {
            using (PhoneCompanyContext context = new PhoneCompanyContext())
            {
                context.ClientTypes.Remove(context.ClientTypes.FirstOrDefault(x => x.TypeName == typeName));
                if (!(context.ClientTypes.Any(x => x.TypeName == typeName)))
                    return true;
                else
                    return false;
            }
        }

        public List<ClientType> GetAllTypes()
        {
            using (PhoneCompanyContext context = new PhoneCompanyContext())
            {
                return context.ClientTypes.Select(x => x.DbToCommon()).ToList();
            }
        }

        public ClientType GetTypeByName(string typeName)
        {
            using (PhoneCompanyContext context = new PhoneCompanyContext())
            {
                return context.ClientTypes.FirstOrDefault(x => x.TypeName == typeName).DbToCommon();
            }
        }

        public void UpdateMinutePrice(string typeName, double newPrice)
        {
            using (PhoneCompanyContext context = new PhoneCompanyContext())
            {
                context.ClientTypes.FirstOrDefault(x => x.TypeName == typeName)
                                   .MinutePrice = newPrice;
                context.SaveChanges();
            }
        }

        public void UpdateSMSPrice(string typeName, double newPrice)
        {
            using (PhoneCompanyContext context = new PhoneCompanyContext())
            {
                context.ClientTypes.FirstOrDefault(x => x.TypeName == typeName)
                                   .SMSPrice = newPrice;
                context.SaveChanges();
            }
        }
    }
}