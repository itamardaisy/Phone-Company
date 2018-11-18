using Common.Interfaces;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Repositories
{
    public class PackageRepository : IPackageRepository
    {
        public Package AddNewPackage(Package package)
        {
            throw new NotImplementedException();
        }

        public bool DeletePackage(string packageName)
        {
            throw new NotImplementedException();
        }

        public Package GetPackageByName(string packageName)
        {
            throw new NotImplementedException();
        }

        public bool UpdatePackage(int id, Package package)
        {
            throw new NotImplementedException();
        }
    }
}
