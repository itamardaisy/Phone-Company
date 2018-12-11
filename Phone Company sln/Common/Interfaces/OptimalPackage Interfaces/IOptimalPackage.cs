using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces.OptimalPackage_Interfaces
{
    public interface IOptimalPackage
    {
        List<Package> GetOptimalPackage(Client client, string packageName);
    }
}
