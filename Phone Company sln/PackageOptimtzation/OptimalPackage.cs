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
            PhoneCompanyContext context = new PhoneCompanyContext();
            PACKAGE_REPOSITORY = new PackageRepository(context);
        }

        public Package GetOptimalPackage(Client client, string packageName)
        {
            return PACKAGE_REPOSITORY.GetPackageByName(packageName);
        }
    }
}
