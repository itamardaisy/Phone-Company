using Dal.DataModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.DataInitializer
{
    public class PhoneCompanyContext : DbContext
    {
        public PhoneCompanyContext() : base("PhoneCompanyDb")
        {
            Database.SetInitializer(new DbInit());
        }

        public virtual DbSet<DbCall> Calls { get; set; }
        public virtual DbSet<DbClient> Clients { get; set; }
        public DbSet<DbClientType> ClientTypes { get; set; }
        public virtual DbSet<DbLine> Lines { get; set; }
        public DbSet<DbPackage> Packages { get; set; }
        public virtual DbSet<DbPayment> Payments { get; set; }
        public DbSet<DbSelectedNumber> SelectedNumbers { get; set; }
        public virtual DbSet<DbSMS> SMSs { get; set; }
        public DbSet<DbUnsignClient> UnsignClients { get; set; }
        public DbSet<DbUser> Users { get; set; }
    }
}