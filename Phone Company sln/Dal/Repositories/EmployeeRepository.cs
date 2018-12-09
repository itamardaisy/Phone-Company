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
        public User EmployeeLogin(string name, string password)
        {
            try
            {
                using (PhoneCompanyContext context = new PhoneCompanyContext())
                {
                    return context.Users.
                    Where(x => x.Name == name && x.Password == password)
                    .FirstOrDefault().DbToCommon();
                }
            }
            catch (ArgumentNullException ex)
            {
                Services.WriteExceptionsToLogger(ex);
                throw new GetFromDatabaseException(ex.Message);
            }
            catch (Exception ex)
            {
                Services.WriteExceptionsToLogger(ex);
                throw new Exception(ex.Message);
            }
        }
    }
}