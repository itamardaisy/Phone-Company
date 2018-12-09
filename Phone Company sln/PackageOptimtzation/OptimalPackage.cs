using Common.Models;
using Dal.DataInitializer;
using Dal.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageOptimtzation
{
    public class OptimalPackage
    {
        private readonly PackageRepository PACKAGE_REPOSITORY;

        public OptimalPackage()
        {
            PACKAGE_REPOSITORY = new PackageRepository();
        }

        public List<Package> GetOptimalPackage(Client client, string packageName)
        {
            List<Package> packages = new List<Package>();
            packages.Add(PACKAGE_REPOSITORY.GetPackageByName(packageName));
            return packages;
        }
    }
}
