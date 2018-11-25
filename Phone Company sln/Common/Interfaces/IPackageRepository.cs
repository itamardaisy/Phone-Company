using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IPackageRepository
    {
        void AddNewPackage(Package package);

        bool DeletePackage(string packageName);

        Package GetPackageByName(string packageName);

        void UpdatePackage(Package package);
    }
}
