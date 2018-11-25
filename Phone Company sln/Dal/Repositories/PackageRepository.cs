using Common.Interfaces;
using Common.Models;
using Dal.DataInitializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.ModelConverters;
using Dal.DataModels;

namespace Dal.Repositories
{
    public class PackageRepository : IPackageRepository
    {
        public void AddNewPackage(Package package)
        {
            using(PhoneCompanyContext context = new PhoneCompanyContext())
            {
                context.Packages.Add(package.CommonToDb());
                context.SaveChanges();
            }
        }

        public bool DeletePackage(string packageName)
        {
            using(PhoneCompanyContext context = new PhoneCompanyContext())
            {
                context.Packages.Remove(context.Packages.FirstOrDefault(x => x.PackageName == packageName));
                if (!(context.Packages.Any(x => x.PackageName == packageName)))
                    return true;
                else
                    return false;
            }
        }

        public Package GetPackageByName(string packageName)
        {
            using(PhoneCompanyContext context = new PhoneCompanyContext())
            {
                return context.Packages.FirstOrDefault(x => x.PackageName == packageName).DbToCommon();
            }
        }

        public void UpdatePackage(Package package)
        {
            using(PhoneCompanyContext context = new PhoneCompanyContext())
            {
                DbPackage dbPackage = context.Packages.FirstOrDefault(x => x.Id == package.Id);
                UpdateThePackageProperties(dbPackage, package);
                context.SaveChanges();
            }
        }

        private void UpdateThePackageProperties(DbPackage dbPackage, Package package)
        {
            dbPackage.DisscountPrecentage = package.DisscountPrecentage;
            dbPackage.FixedPrice = package.FixedPrice;
            dbPackage.Id = package.Id;
            dbPackage.InsideFamilyCall = package.InsideFamilyCall;
            dbPackage.MaxMinute = package.MaxMinute;
            dbPackage.MostCallNumber = package.MostCallNumber;
            dbPackage.PackageName = package.PackageName;
            dbPackage.SelectedNuberId = package.SelectedNumberId;
            dbPackage.TotalPrice = package.TotalPrice;
        }
    }
}
