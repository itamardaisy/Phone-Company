using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface ILoginService
    {
        object Login(string name, string password);

        bool Logout(int id);
    }
}
