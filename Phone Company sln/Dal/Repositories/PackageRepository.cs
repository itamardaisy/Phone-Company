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
           
        }

        public bool DeletePackage(string packageName)
        {
            /*
             * This function needs to delete a spesific package. 
             * on the delete it needs to fine which customer is using this package and change they're package to other one.
             * 
             * parameters:
             *      packageName - the wanted package name.
             *      
             * return:
             *      true if the operation sacceed. otherwise false.
             * 
             */

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
