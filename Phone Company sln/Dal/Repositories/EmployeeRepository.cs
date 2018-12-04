using Common.Interfaces.Repository_interfaces;
using Common.Models;
using Dal.DataInitializer;
using Dal.ModelConverters;

using Dal.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.EnvironmentService;
using Common.Exceptions;

namespace Dal.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private PhoneCompanyContext context;


        public EmployeeRepository(PhoneCompanyContext context)
        {
            this.context = context;
        }

        public User EmployeeLogin(string name, string password)
        {
            try
            {
                return context.Users.
                    Where(x => x.Name == name && x.Password == password)
                    .FirstOrDefault().DbToCommon();
               // return userDB.DbToCommon();
            }
            catch (ArgumentNullException ex)
            {
                Services.WriteExceptionsToLogger(ex);
                throw new GetFromDatabaseException(ex.Message);
            }                          
        }
    }
}
