using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces.UI.Client_Interfaces
{
    public interface ILoginService
    {
        Client Login(string name, string phoneNumber);
    }
}
