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
            //context.Users.AddOrUpdate(new DbUser { CallAnswer = 0, SignDate = DateTime.Now, Email = "itadafefww@mdsf.com", Name = "Baba", Password = "1234", Type = UserType.Manager });
            //context.ClientTypes.AddOrUpdate(new DbClientType { Id = 1, MinutePrice = 1.0, SMSPrice = 1.5, TypeName = "Regular" });
            //context.Packages.AddOrUpdate(new DbPackage { DisscountPrecentage = 0, FixedPrice = 100, InsideFamilyCall = false, MaxMinute = 200, MostCallNumber = false, PackageName = "DefaultPackage", TotalPrice = 100, MaxSMSs = 100 });
            //context.Clients.AddOrUpdate(new DbClient { CallToCenter = 0, Adress = "Raanana, Ahar 7/5", ClientTypeId = 1, ContactNumber = "0545822126", SignDate = DateTime.Now, LastName = "Daisy", Name = "Itamar", UserId = 1 });
        }
    }
}