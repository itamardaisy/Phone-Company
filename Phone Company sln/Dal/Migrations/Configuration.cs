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
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            try
            {
                string dateFormat = "MM/dd/yyyy";
                CultureInfo provider = CultureInfo.InvariantCulture;
                context.Users.AddOrUpdate(new DbUser { Name = "itamar", CallAnswer = 100, Email = "itamardaisy@gmail.com", Password = "1234", SignDate = DateTime.Now, Type = (UserType)1 });
                context.Users.AddOrUpdate(new DbUser { Name = "itamar", CallAnswer = 100, Email = "itamardaisy@gmail.com", Password = "1234", SignDate = DateTime.Now, Type = (UserType)1 });
                context.Users.AddOrUpdate(new DbUser { Name = "itamar", CallAnswer = 100, Email = "itamardaisy@gmail.com", Password = "1234", SignDate = DateTime.Now, Type = (UserType)1 });
                context.Clients.AddOrUpdate(new DbClient { Name = "yoni", LastName = "fifo", ClientTypeId = 2, CallToCenter = 43, ContactNumber = "0547591724", Adress = "Tel Aviv Rotchild 4/3B", SignDate = DateTime.ParseExact("04/23/2016", dateFormat, provider), UserId = 3 });
                context.Clients.AddOrUpdate(new DbClient { Name = "nir", LastName = "london", ClientTypeId = 2, CallToCenter = 43, ContactNumber = "0849293347", Adress = "Tel Aviv Rotchild 4/3B", SignDate = DateTime.ParseExact("04/23/2016", dateFormat, provider), UserId = 3 });
                context.Clients.AddOrUpdate(new DbClient { Name = "avi", LastName = "hadad", ClientTypeId = 2, CallToCenter = 43, ContactNumber = "0548293214", Adress = "Tel Aviv Rotchild 4/3B", SignDate = DateTime.ParseExact("04/23/2016", dateFormat, provider), UserId = 3 });
                context.Clients.AddOrUpdate(new DbClient { Name = "oleg", LastName = "fifo", ClientTypeId = 2, CallToCenter = 43, ContactNumber = "0526374842", Adress = "Tel Aviv Rotchild 4/3B", SignDate = DateTime.ParseExact("04/23/2016", dateFormat, provider), UserId = 3 });
                context.Clients.AddOrUpdate(new DbClient { Name = "itamar", LastName = "daisy", ClientTypeId = 2, CallToCenter = 43, ContactNumber = "0849293346", Adress = "Tel Aviv Rotchild 4/3B", SignDate = DateTime.ParseExact("04/23/2016", dateFormat, provider), UserId = 3 });
                context.Clients.AddOrUpdate(new DbClient { Name = "hani", LastName = "fifo", ClientTypeId = 2, CallToCenter = 43, ContactNumber = "0849293841", Adress = "Tel Aviv Rotchild 4/3B", SignDate = DateTime.ParseExact("04/23/2016", dateFormat, provider), UserId = 3 });
                context.Clients.AddOrUpdate(new DbClient { Name = "yoni", LastName = "fifo", ClientTypeId = 2, CallToCenter = 43, ContactNumber = "0849593344", Adress = "Tel Aviv Rotchild 4/3B", SignDate = DateTime.ParseExact("04/23/2016", dateFormat, provider), UserId = 3 });
                context.Clients.AddOrUpdate(new DbClient { Name = "benny", LastName = "fifo", ClientTypeId = 2, CallToCenter = 43, ContactNumber = "0524374832", Adress = "Tel Aviv Rotchild 4/3B", SignDate = DateTime.ParseExact("04/23/2016", dateFormat, provider), UserId = 3 });
                context.Clients.AddOrUpdate(new DbClient { Name = "shany", LastName = "fifo", ClientTypeId = 2, CallToCenter = 43, ContactNumber = "0522374832", Adress = "Tel Aviv Rotchild 4/3B", SignDate = DateTime.ParseExact("04/23/2016", dateFormat, provider), UserId = 3 });
                context.Clients.AddOrUpdate(new DbClient { Name = "ron", LastName = "fifo", ClientTypeId = 2, CallToCenter = 43, ContactNumber = "0573647554", Adress = "Tel Aviv Rotchild 4/3B", SignDate = DateTime.ParseExact("04/23/2016", dateFormat, provider), UserId = 3 });
                context.Clients.AddOrUpdate(new DbClient { Name = "guy", LastName = "fifo", ClientTypeId = 2, CallToCenter = 43, ContactNumber = "0849243344", Adress = "Tel Aviv Rotchild 4/3B", SignDate = DateTime.ParseExact("04/23/2016", dateFormat, provider), UserId = 3 });
                context.ClientTypes.AddOrUpdate(new DbClientType { MinutePrice = 1.0, SMSPrice = 1.0, TypeName = "VIP" });
                context.ClientTypes.AddOrUpdate(new DbClientType { MinutePrice = 1.0, SMSPrice = 1.0, TypeName = "Regular" });
                context.ClientTypes.AddOrUpdate(new DbClientType { MinutePrice = 1.0, SMSPrice = 1.0, TypeName = "Pro" });
                context.ClientTypes.AddOrUpdate(new DbClientType { MinutePrice = 1.0, SMSPrice = 1.0, TypeName = "Regular Plus" });
                context.Calls.AddOrUpdate(new DbCall { LineId = 2, CallDate = DateTime.ParseExact("04/23/2016", dateFormat, provider), DestinationNumber = "0573647554", Duration = 4.5 });
                context.Calls.AddOrUpdate(new DbCall { LineId = 6, CallDate = DateTime.ParseExact("07/23/2016", dateFormat, provider), DestinationNumber = "0573647554", Duration = 4.4 });
                context.Calls.AddOrUpdate(new DbCall { LineId = 3, CallDate = DateTime.ParseExact("04/23/2016", dateFormat, provider), DestinationNumber = "0548293844", Duration = 4.5 });
                context.Calls.AddOrUpdate(new DbCall { LineId = 2, CallDate = DateTime.ParseExact("03/23/2016", dateFormat, provider), DestinationNumber = "0528293844", Duration = 4.5 });
                context.Calls.AddOrUpdate(new DbCall { LineId = 6, CallDate = DateTime.ParseExact("03/23/2016", dateFormat, provider), DestinationNumber = "0849593344", Duration = 4.5 });
                context.Calls.AddOrUpdate(new DbCall { LineId = 9, CallDate = DateTime.ParseExact("08/23/2016", dateFormat, provider), DestinationNumber = "0849293344", Duration = 4.5 });
                context.Calls.AddOrUpdate(new DbCall { LineId = 10, CallDate = DateTime.ParseExact("04/23/2016", dateFormat, provider), DestinationNumber = "0849293844", Duration = 4.5 });
                context.Calls.AddOrUpdate(new DbCall { LineId = 3, CallDate = DateTime.ParseExact("04/23/2016", dateFormat, provider), DestinationNumber = "0547591724", Duration = 5.2 });
                context.Calls.AddOrUpdate(new DbCall { LineId = 1, CallDate = DateTime.ParseExact("04/23/2016", dateFormat, provider), DestinationNumber = "0548293214", Duration = 4.27 });
                context.Calls.AddOrUpdate(new DbCall { LineId = 4, CallDate = DateTime.ParseExact("04/23/2016", dateFormat, provider), DestinationNumber = "0573647244", Duration = 4.5 });
                context.Calls.AddOrUpdate(new DbCall { LineId = 3, CallDate = DateTime.ParseExact("04/23/2016", dateFormat, provider), DestinationNumber = "0573647244", Duration = 1.8 });
                context.Lines.AddOrUpdate(new DbLine { ClientId = 3, Number = "0849243344", PackageId = 2, Status = false });
                context.Lines.AddOrUpdate(new DbLine { ClientId = 3, Number = "0573647554", PackageId = 2, Status = false });
                context.Lines.AddOrUpdate(new DbLine { ClientId = 3, Number = "0522374832", PackageId = 2, Status = false });
                context.Lines.AddOrUpdate(new DbLine { ClientId = 3, Number = "0524374832", PackageId = 2, Status = false });
                context.Lines.AddOrUpdate(new DbLine { ClientId = 3, Number = "0849593344", PackageId = 2, Status = false });
                context.Lines.AddOrUpdate(new DbLine { ClientId = 3, Number = "0849293841", PackageId = 2, Status = false });
                context.Lines.AddOrUpdate(new DbLine { ClientId = 3, Number = "0849293346", PackageId = 2, Status = false });
                context.Lines.AddOrUpdate(new DbLine { ClientId = 3, Number = "0526374842", PackageId = 2, Status = false });
                context.Lines.AddOrUpdate(new DbLine { ClientId = 3, Number = "0548293214", PackageId = 2, Status = false });
                context.Lines.AddOrUpdate(new DbLine { ClientId = 3, Number = "0849293347", PackageId = 2, Status = false });
                context.Lines.AddOrUpdate(new DbLine { ClientId = 3, Number = "0547591724", PackageId = 2, Status = false });
                context.Packages.AddOrUpdate(new DbPackage { PackageName = "Pro package", DisscountPrecentage = 25, FixedPrice = 100, InsideFamilyCall = true, MaxMinute = 400, MostCallNumber = true, SelectedNuberId = 2, TotalPrice = 400 });
                context.Packages.AddOrUpdate(new DbPackage { PackageName = "Regular package", DisscountPrecentage = 0, FixedPrice = 200, InsideFamilyCall = false, MaxMinute = 200, MostCallNumber = true, SelectedNuberId = 2, TotalPrice = 500 });
                context.Packages.AddOrUpdate(new DbPackage { PackageName = "Regular Plus package", DisscountPrecentage = 10, FixedPrice = 150, InsideFamilyCall = true, MaxMinute = 300, MostCallNumber = true, SelectedNuberId = 2, TotalPrice = 450 });
                context.Packages.AddOrUpdate(new DbPackage { PackageName = "VIP package", DisscountPrecentage = 25, FixedPrice = 80, InsideFamilyCall = true, MaxMinute = 400, MostCallNumber = true, SelectedNuberId = 2, TotalPrice = 300 });
                context.Payments.AddOrUpdate(new DbPayment { ClientId = 2, Month = DateTime.Now, TotalPayment = 400 });
                context.Payments.AddOrUpdate(new DbPayment { ClientId = 1, Month = DateTime.Now, TotalPayment = 300 });
                context.Payments.AddOrUpdate(new DbPayment { ClientId = 1, Month = DateTime.Now, TotalPayment = 450 });
                context.Payments.AddOrUpdate(new DbPayment { ClientId = 1, Month = DateTime.Now, TotalPayment = 450 });
                context.Payments.AddOrUpdate(new DbPayment { ClientId = 2, Month = DateTime.Now, TotalPayment = 450 });
                context.Payments.AddOrUpdate(new DbPayment { ClientId = 4, Month = DateTime.Now, TotalPayment = 400 });
                context.Payments.AddOrUpdate(new DbPayment { ClientId = 5, Month = DateTime.Now, TotalPayment = 500 });
                context.Payments.AddOrUpdate(new DbPayment { ClientId = 6, Month = DateTime.Now, TotalPayment = 500 });
                context.Payments.AddOrUpdate(new DbPayment { ClientId = 7, Month = DateTime.Now, TotalPayment = 400 });
                context.Payments.AddOrUpdate(new DbPayment { ClientId = 8, Month = DateTime.Now, TotalPayment = 400 });
                context.Payments.AddOrUpdate(new DbPayment { ClientId = 9, Month = DateTime.Now, TotalPayment = 400 });
                context.SelectedNumbers.AddOrUpdate(new DbSelectedNumber { FirstNumber = "0524374832", SecondNumber = "0526374842", ThirdNumber = "0547591724" });
                context.SelectedNumbers.AddOrUpdate(new DbSelectedNumber { FirstNumber = "0849293347", SecondNumber = "0526374842", ThirdNumber = "0547591724" });
                context.SelectedNumbers.AddOrUpdate(new DbSelectedNumber { FirstNumber = "0524374832", SecondNumber = "0849293346", ThirdNumber = "0547591724" });
                context.SelectedNumbers.AddOrUpdate(new DbSelectedNumber { FirstNumber = "0849293346", SecondNumber = "0526374842", ThirdNumber = "0547591724" });
                context.SelectedNumbers.AddOrUpdate(new DbSelectedNumber { FirstNumber = "0524374832", SecondNumber = "0526374842", ThirdNumber = "0849293346" });
                context.SelectedNumbers.AddOrUpdate(new DbSelectedNumber { FirstNumber = "0524374832", SecondNumber = "0526374842", ThirdNumber = "0547591724" });
                context.SelectedNumbers.AddOrUpdate(new DbSelectedNumber { FirstNumber = "0524374832", SecondNumber = "0526374842", ThirdNumber = "0849293346" });
                context.SelectedNumbers.AddOrUpdate(new DbSelectedNumber { FirstNumber = "0524374832", SecondNumber = "0849293347", ThirdNumber = "0547591724" });
                context.SelectedNumbers.AddOrUpdate(new DbSelectedNumber { FirstNumber = "0524374832", SecondNumber = "0526374842", ThirdNumber = "0547591724" });
                context.SelectedNumbers.AddOrUpdate(new DbSelectedNumber { FirstNumber = "0849293346", SecondNumber = "0849293346", ThirdNumber = "0547591724" });
                context.SelectedNumbers.AddOrUpdate(new DbSelectedNumber { FirstNumber = "0524374832", SecondNumber = "0849243344", ThirdNumber = "0849293347" });
                context.SMSs.AddOrUpdate(new DbSMS { DestinationNumber = "0524374832", ExternalPrice = 4.5, LineId = 3, SMSDate = DateTime.Now });
                context.SMSs.AddOrUpdate(new DbSMS { DestinationNumber = "0849293347", ExternalPrice = 4.5, LineId = 1, SMSDate = DateTime.Now });
                context.SMSs.AddOrUpdate(new DbSMS { DestinationNumber = "0849293346", ExternalPrice = 4.5, LineId = 4, SMSDate = DateTime.Now });
                context.SMSs.AddOrUpdate(new DbSMS { DestinationNumber = "0526374842", ExternalPrice = 4.5, LineId = 5, SMSDate = DateTime.Now });
                context.SMSs.AddOrUpdate(new DbSMS { DestinationNumber = "0547591724", ExternalPrice = 4.5, LineId = 7, SMSDate = DateTime.Now });
                context.Calls.AddOrUpdate(new DbCall { LineId = 3, CallDate = DateTime.Now, DestinationNumber = "0526374842", Duration = 5.7 });
                context.Calls.AddOrUpdate(new DbCall { LineId = 4, CallDate = DateTime.Now, DestinationNumber = "0524374832", Duration = 5.7 });
                context.Calls.AddOrUpdate(new DbCall { LineId = 5, CallDate = DateTime.Now, DestinationNumber = "0849293346", Duration = 5.7 });
                context.Calls.AddOrUpdate(new DbCall { LineId = 7, CallDate = DateTime.Now, DestinationNumber = "0547591724", Duration = 5.7 });
                context.Calls.AddOrUpdate(new DbCall { LineId = 1, CallDate = DateTime.Now, DestinationNumber = "0849243344", Duration = 5.7 });
                context.UnsignClients.AddOrUpdate(new DbUnsignClient { Name = "yoni", LastName = "gogi", ClientTypeId = 2, CallToCenter = 43, ContactNumber = "0555591724", Adress = "Tel Aviv Rotchild 4/3B", SignDate = DateTime.ParseExact("04/23/2016", dateFormat, provider), UserId = 3 });
                context.SaveChanges();

            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }
    }
}