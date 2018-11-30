using Common.Interfaces;
using Common.Models;
using Dal.DataInitializer;
using System.Linq;
using Dal.ModelConverters;
using Dal.DataModels;
using System.Collections.Generic;
using System;
using Common.EnvironmentService;
using Common.Exceptions;
using System.Data.Entity.Migrations;

namespace Dal.Repositories
{
    public class PackageRepository : IPackageRepository
    {
        PhoneCompanyContext context;

        public PackageRepository(PhoneCompanyContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// This method gets the package from the BL and add it to the contexxt.
        /// </summary>
        /// <param name="package"> Indeicate the new package </param>
        public void AddNewPackage(Package package)
        {
            try
            {
                context.Packages.Add(package.CommonToDb());
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Services.WriteExceptionsToLogger(ex);
                throw new DataProcedureException(ex.Message);
            }
        }

        /// <summary>
        /// This function needs to delete a spesific package.
        /// on the delete it needs to fine which customer is using this package and change they're package to other one.
        /// </summary>
        /// 
        /// <param name="packageName"> The wanted package name </param>
        /// 
        /// <returns> True if the operation sacceed. otherwise false.  </returns>
        public bool DeletePackage(string packageName)
        {
            try
            {
                var wantedPackage = context.Packages.FirstOrDefault(x => x.PackageName == packageName);
                List<Client> packageClients = GetPackageClients(packageName);
                for (int i = 0; i < packageClients.Count; i++)
                    ChangeToDefaultPackage(packageClients[i].Id);
                context.Packages.Remove(context.Packages.FirstOrDefault(x => x.PackageName == packageName));
                context.SaveChanges();
                if (!context.Packages.Any(x => x.PackageName == packageName))
                    return true;
                else
                    return false;
            }
            catch (ArgumentNullException ex)
            {
                Services.WriteExceptionsToLogger(ex);
                throw new GetFromDatabaseException(ex.Message);
            }
            catch (Exception ex)
            {
                Services.WriteExceptionsToLogger(ex);
                throw new DataProcedureException(ex.Message);
            }
        }

        /// <summary>
        /// This method will return the list of the client that use the wanted package.
        /// </summary>
        /// <param name="packageName"> The wanted package name. </param>
        /// <returns> The list of the clients. </returns>
        public List<Client> GetPackageClients(string packageName)
        {
            try
            {
                return context.Lines.Where(x => x.Package.PackageName == packageName)
                       .Select(x => x.Client.DbToCommon()).ToList();
            }
            catch (ArgumentNullException ex)
            {
                Services.WriteExceptionsToLogger(ex);
                throw new GetFromDatabaseException(ex.Message);
            }
        }

        /// <summary>
        /// This method is gets a package from the context and convert it to the common model.
        /// </summary>
        /// <param name="packageName"> The specific package name. </param>
        /// <returns> The wanted package. </returns>
        public Package GetPackageByName(string packageName)
        {
            try
            {
                return context.Packages.FirstOrDefault(x => x.PackageName == packageName).DbToCommon();
            }
            catch (ArgumentNullException ex)
            {
                Services.WriteExceptionsToLogger(ex);
                throw new GetFromDatabaseException(ex.Message);
            }
        }

        /// <summary>
        /// This method getting a package from the BL and replace it with the wanted package to update.
        /// </summary>
        /// <param name="package"></param>
        public void UpdatePackage(Package package)
        {
            try
            {
                DbPackage dbPackage = context.Packages.FirstOrDefault(x => x.Id == package.Id);
                UpdateThePackageProperties(dbPackage, package);
                context.SaveChanges();
            }
            catch (ArgumentNullException ex)
            {
                Services.WriteExceptionsToLogger(ex);
                throw new GetFromDatabaseException(ex.Message);
            }
        }

        /// <summary>
        /// This is a private method that initiate to actualy update the package.
        /// </summary>
        /// <param name="dbPackage"> The database package </param>
        /// <param name="package"> The update package </param>
        private void UpdateThePackageProperties(DbPackage dbPackage, Package package)
        {
            dbPackage.DisscountPrecentage = package.DisscountPrecentage;
            dbPackage.FixedPrice = package.FixedPrice;
            dbPackage.Id = package.Id;
            dbPackage.InsideFamilyCall = package.InsideFamilyCall;
            dbPackage.MaxMinute = package.MaxMinute;
            dbPackage.MostCallNumber = package.MostCallNumber;
            dbPackage.PackageName = package.PackageName;
            dbPackage.SelectedNumberId = package.SelectedNumberId;
            dbPackage.TotalPrice = package.TotalPrice;
        }

        /// <summary>
        /// Tish method gets the client Id and chage his package to the default package.
        /// </summary>
        /// <param name="clientId"> The wanted ClientId</param>
        private void ChangeToDefaultPackage(int clientId)
        {
            try
            {
                int defaultPackageId = context.Packages.FirstOrDefault(x => x.PackageName == "DefaultPackage").Id;
                context.Lines.FirstOrDefault(x => x.ClientId == clientId).PackageId = defaultPackageId;
                context.SaveChanges();
            }
            catch (ArgumentNullException ex)
            {
                Services.WriteExceptionsToLogger(ex);
                throw new GetFromDatabaseException(ex.Message);
            }
            catch (Exception ex)
            {
                Services.WriteExceptionsToLogger(ex);
                throw new DataProcedureException(ex.Message);
            }
        }
    }
}