namespace Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class _new : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DbCalls",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    LineId = c.Int(nullable: false),
                    Duration = c.Double(nullable: false),
                    CallDate = c.DateTime(nullable: false),
                    DestinationNumber = c.String(nullable: false),
                    FamilyCall = c.Boolean(nullable: false),
                    SelectedNumberCall = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DbLines", t => t.LineId, cascadeDelete: true)
                .Index(t => t.LineId);

            CreateTable(
                "dbo.DbLines",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    PackageId = c.Int(nullable: false),
                    ClientId = c.Int(nullable: false),
                    Number = c.String(nullable: false),
                    Status = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DbClients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.DbPackages", t => t.PackageId, cascadeDelete: true)
                .Index(t => t.PackageId)
                .Index(t => t.ClientId);

            CreateTable(
                "dbo.DbClients",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false),
                    LastName = c.String(nullable: false),
                    ClientTypeId = c.Int(nullable: false),
                    Adress = c.String(nullable: false),
                    ContactNumber = c.String(nullable: false),
                    SignDate = c.DateTime(nullable: false),
                    CallToCenter = c.Int(nullable: false),
                    UserId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DbClientTypes", t => t.ClientTypeId, cascadeDelete: true)
                .ForeignKey("dbo.DbUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.ClientTypeId)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.DbClientTypes",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    TypeName = c.String(nullable: false),
                    MinutePrice = c.Double(nullable: false),
                    SMSPrice = c.Double(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.DbUsers",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false),
                    Email = c.String(nullable: false),
                    Password = c.String(nullable: false),
                    CallAnswer = c.Int(nullable: false),
                    SignDate = c.DateTime(nullable: false),
                    Type = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.DbPackages",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    SelectedNumberId = c.Boolean(nullable: false),
                    PackageName = c.String(nullable: false),
                    TotalPrice = c.Double(nullable: false),
                    MaxMinute = c.Int(nullable: false),
                    MaxSMSs = c.Int(nullable: false),
                    FixedPrice = c.Double(nullable: false),
                    DisscountPrecentage = c.Int(nullable: false),
                    MostCallNumber = c.Boolean(nullable: false),
                    InsideFamilyCall = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.DbPayments",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    LineId = c.Int(nullable: false),
                    Month = c.DateTime(nullable: false),
                    TotalPayment = c.Double(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DbLines", t => t.LineId, cascadeDelete: true)
                .Index(t => t.LineId);

            CreateTable(
                "dbo.DbSelectedNumbers",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    LineId = c.Int(nullable: false),
                    FirstNumber = c.String(nullable: false),
                    SecondNumber = c.String(nullable: false),
                    ThirdNumber = c.String(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DbLines", t => t.LineId, cascadeDelete: true)
                .Index(t => t.LineId);

            CreateTable(
                "dbo.DbSMS",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    ExternalPrice = c.Double(nullable: false),
                    LineId = c.Int(nullable: false),
                    SmsDate = c.DateTime(nullable: false),
                    DestinationNumber = c.String(nullable: false),
                    FamilyCall = c.Boolean(nullable: false),
                    SelectedNumberCall = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DbLines", t => t.LineId, cascadeDelete: true)
                .Index(t => t.LineId);

            CreateTable(
                "dbo.DbUnsignClients",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false),
                    LastName = c.String(nullable: false),
                    ClientTypeId = c.Int(nullable: false),
                    Adress = c.String(nullable: false),
                    ContactNumber = c.String(nullable: false),
                    SignDate = c.DateTime(nullable: false),
                    UnsignDate = c.DateTime(nullable: false),
                    CallToCenter = c.Int(nullable: false),
                    UserId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DbClientTypes", t => t.ClientTypeId, cascadeDelete: true)
                .ForeignKey("dbo.DbUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.ClientTypeId)
                .Index(t => t.UserId);
        }

        public override void Down()
        {
            DropForeignKey("dbo.DbUnsignClients", "UserId", "dbo.DbUsers");
            DropForeignKey("dbo.DbUnsignClients", "ClientTypeId", "dbo.DbClientTypes");
            DropForeignKey("dbo.DbSMS", "LineId", "dbo.DbLines");
            DropForeignKey("dbo.DbSelectedNumbers", "LineId", "dbo.DbLines");
            DropForeignKey("dbo.DbPayments", "LineId", "dbo.DbLines");
            DropForeignKey("dbo.DbCalls", "LineId", "dbo.DbLines");
            DropForeignKey("dbo.DbLines", "PackageId", "dbo.DbPackages");
            DropForeignKey("dbo.DbLines", "ClientId", "dbo.DbClients");
            DropForeignKey("dbo.DbClients", "UserId", "dbo.DbUsers");
            DropForeignKey("dbo.DbClients", "ClientTypeId", "dbo.DbClientTypes");
            DropIndex("dbo.DbUnsignClients", new[] { "UserId" });
            DropIndex("dbo.DbUnsignClients", new[] { "ClientTypeId" });
            DropIndex("dbo.DbSMS", new[] { "LineId" });
            DropIndex("dbo.DbSelectedNumbers", new[] { "LineId" });
            DropIndex("dbo.DbPayments", new[] { "LineId" });
            DropIndex("dbo.DbClients", new[] { "UserId" });
            DropIndex("dbo.DbClients", new[] { "ClientTypeId" });
            DropIndex("dbo.DbLines", new[] { "ClientId" });
            DropIndex("dbo.DbLines", new[] { "PackageId" });
            DropIndex("dbo.DbCalls", new[] { "LineId" });
            DropTable("dbo.DbUnsignClients");
            DropTable("dbo.DbSMS");
            DropTable("dbo.DbSelectedNumbers");
            DropTable("dbo.DbPayments");
            DropTable("dbo.DbPackages");
            DropTable("dbo.DbUsers");
            DropTable("dbo.DbClientTypes");
            DropTable("dbo.DbClients");
            DropTable("dbo.DbLines");
            DropTable("dbo.DbCalls");
        }
    }
}