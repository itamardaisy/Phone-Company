using Common.Interfaces;
using Common.Models;
using Dal.DataInitializer;
using Dal.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class LoginService : IEmploeeLoginService
    {
        private readonly EmployeeRepository _employeeRepository;

        public LoginService()
        {
            PhoneCompanyContext context = new PhoneCompanyContext();

            _employeeRepository = new EmployeeRepository();
        }

        public User Login(string name, string password)
        {
            return _employeeRepository.EmployeeLogin(name, password);
        }

        public bool Logout(int id)
        {
            throw new NotImplementedException();
        }
    }
}