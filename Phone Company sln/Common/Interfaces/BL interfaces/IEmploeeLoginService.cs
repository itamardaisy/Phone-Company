using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IEmploeeLoginService
    {
        User Login(string name, string password);

        bool Logout(int id);
    }
}