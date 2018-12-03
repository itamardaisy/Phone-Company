using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces.ClientBL_Interfaces
{
    public interface IClientLoginService
    {
        bool Login(string name, int clientId);
    }
}
