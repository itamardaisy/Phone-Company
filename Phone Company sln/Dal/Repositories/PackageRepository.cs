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

using Dal.ModelConverters;

namespace Dal.Repositories
{
    public class PackageRepository : IPackageRepository
    {
        public void AddNewPackage(Package package)
        {
            using (PhoneCompanyContext context = new PhoneCompanyContext())
            {
                context.Packages.Add(package.CommonToDb());
                context.SaveChanges();
            }
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
            return false;
            //List<Client> packageClients;
            //using (PhoneCompanyContext context = new PhoneCompanyContext())
            //{
            //    var wantedPackage = context.Packages.Where(x => x.PackageName == packageName).FirstOrDefault();
            //    //packageClients = context.Lines.Where(x => x.PackageId == wantedPackage.Id).Select(x => x.DbToCommon()).ToList();
            //}
        }

        public Package GetPackageByName(string packageName)
        {
            using (PhoneCompanyContext context = new PhoneCompanyContext())
            {
                return context.Packages.FirstOrDefault(x => x.PackageName == packageName).DbToCommon();
            }
        }

        public void UpdatePackage(Package package)
        {
            using (PhoneCompanyContext context = new PhoneCompanyContext())
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