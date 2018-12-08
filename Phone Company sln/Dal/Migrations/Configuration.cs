namespace Dal.Migrations
{
    using Common.Enums;
    using Dal.DataModels;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Diagnostics;
    using System.Globalization;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Dal.DataInitializer.PhoneCompanyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Dal.DataInitializer.PhoneCompanyContext context)
        {
            context.Packages.AddOrUpdate(new DbPackage { DisscountPrecentage = 0, FixedPrice = 100, InsideFamilyCall = false, MaxMinute = 200, MostCallNumber = false, PackageName = "DefaultPackage", TotalPrice = 100,MaxSMSs = 100 });
        }
    }
}