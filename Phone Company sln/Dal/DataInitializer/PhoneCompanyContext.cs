using Common.Enums;
using Dal.DataModels;
using System;
using System.Data.Entity;

namespace Dal.DataInitializer
{
    public class PhoneCompanyContext : DbContext
    {
        public PhoneCompanyContext() : base("PhoneCompanyDb")
        {
            Database.SetInitializer<PhoneCompanyContext>(new Init());
        }
        public virtual DbSet<DbCall> Calls { get; set; }
        public virtual DbSet<DbClient> Clients { get; set; }
        public DbSet<DbClientType> ClientTypes { get; set; }
        public virtual DbSet<DbLine> Lines { get; set; }
        public DbSet<DbPackage> Packages { get; set; }
        public virtual DbSet<DbPayment> Payments { get; set; }
        public DbSet<DbSelectedNumber> SelectedNumbers { get; set; }
        public virtual DbSet<DbSMS> SMSs { get; set; }
        public virtual DbSet<DbUnsignClient> UnsignClients { get; set; }
        public DbSet<DbUser> Users { get; set; }
    }

    internal class Init : DropCreateDatabaseAlways<PhoneCompanyContext>
    {
        protected override void Seed(PhoneCompanyContext context)
        {
            context.Users.Add(new DbUser { Id = 1, CallAnswer = 0, SignDate = DateTime.Now, Email = "itadafefww@mdsf.com", Name = "Baba", Password = "1234", Type = UserType.Manager });
            context.Users.Add(new DbUser { Id = 2, CallAnswer = 0, SignDate = DateTime.Now, Email = "itadafefww@mdsf.com", Name = "Mama", Password = "1234", Type = UserType.Emploee });
            context.ClientTypes.Add(new DbClientType { Id = 1, MinutePrice = 1.0, SMSPrice = 1.5, TypeName = "Regular" });
            context.ClientTypes.Add(new DbClientType { Id = 2, MinutePrice = 0.3, SMSPrice = 0.1, TypeName = "VIP" });
            context.ClientTypes.Add(new DbClientType { Id = 3, MinutePrice = 0.6, SMSPrice = 2.0, TypeName = "Family" });
            context.Packages.Add(new DbPackage { Id = 1, DisscountPrecentage = 0, FixedPrice = 100, InsideFamilyCall = false, MaxMinute = 200, MostCallNumber = false, PackageName = "DefaultPackage", TotalPrice = 100, MaxSMSs = 100, SelectedNumberId = false });
            context.Packages.Add(new DbPackage { Id = 2, DisscountPrecentage = 0, FixedPrice = 100, InsideFamilyCall = false, MaxMinute = 200, MostCallNumber = false, PackageName = "DefaultPackage", TotalPrice = 100, MaxSMSs = 100, SelectedNumberId = false });
            context.Packages.Add(new DbPackage { Id = 3, DisscountPrecentage = 0, FixedPrice = 100, InsideFamilyCall = false, MaxMinute = 200, MostCallNumber = false, PackageName = "DefaultPackage", TotalPrice = 100, MaxSMSs = 100, SelectedNumberId = false });
            context.Clients.Add(new DbClient { Id = 1, CallToCenter = 0, Adress = "Raanana, Ahar 7/5", ClientTypeId = 1, ContactNumber = "0545822126", SignDate = DateTime.Now, LastName = "Daisy", Name = "Itamar", UserId = 1 });
            context.Clients.Add(new DbClient { Id = 2, CallToCenter = 0, Adress = "Raanana, Ahar 7/5", ClientTypeId = 1, ContactNumber = "0525822126", SignDate = DateTime.Now, LastName = "Daisy", Name = "Itamar", UserId = 2 });
            context.Clients.Add(new DbClient { Id = 3, CallToCenter = 0, Adress = "Raanana, Ahar 7/5", ClientTypeId = 1, ContactNumber = "0545824126", SignDate = DateTime.Now, LastName = "Daisy", Name = "Itamar", UserId = 2 });
            context.Clients.Add(new DbClient { Id = 4, CallToCenter = 0, Adress = "Raanana, Ahar 7/5", ClientTypeId = 1, ContactNumber = "0545734126", SignDate = DateTime.Now, LastName = "Daisy", Name = "Itamar", UserId = 2 });
            context.Lines.Add(new DbLine { ClientId = 1, Number = "0545822126", Id = 1, PackageId = 1, Status = false });
            context.Lines.Add(new DbLine { ClientId = 2, Number = "0525822126", Id = 2, PackageId = 1, Status = false });
            context.Lines.Add(new DbLine { ClientId = 3, Number = "0545824126", Id = 3, PackageId = 1, Status = false });
            context.Lines.Add(new DbLine { ClientId = 4, Number = "0545734126", Id = 4, PackageId = 1, Status = false });
            context.SelectedNumbers.Add(new DbSelectedNumber { FirstNumber = "0545822126", SecondNumber = "0525822126", ThirdNumber = "0545824126", LineId = 4, Id = 1 });
            context.SaveChanges();
        }
    }
}