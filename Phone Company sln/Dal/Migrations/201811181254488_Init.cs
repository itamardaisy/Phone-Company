namespace Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
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
                        DestinationNumber = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DbLines", t => t.LineId, cascadeDelete: true)
                .Index(t => t.LineId);
            
            CreateTable(
                "dbo.DbLines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(nullable: false),
                        PackageId = c.Int(nullable: false),
                        Number = c.String(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DbClients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.DbPackages", t => t.PackageId, cascadeDelete: true)
                .Index(t => t.ClientId)
                .Index(t => t.PackageId);
            
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
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DbClientTypes", t => t.ClientTypeId, cascadeDelete: true)
                .Index(t => t.ClientTypeId);
            
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
                "dbo.DbPackages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SelectedNuberId = c.Int(nullable: false),
                        PackageName = c.String(nullable: false),
                        TotalPrice = c.Double(nullable: false),
                        MaxMinute = c.Int(nullable: false),
                        FixedPrice = c.Double(nullable: false),
                        DisscountPrecentage = c.Double(nullable: false),
                        MostCallNumber = c.Boolean(nullable: false),
                        InsideFamilyCall = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DbSelectedNumbers", t => t.SelectedNuberId, cascadeDelete: true)
                .Index(t => t.SelectedNuberId);
            
            CreateTable(
                "dbo.DbSelectedNumbers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstNumber = c.String(nullable: false),
                        SecondNumber = c.String(nullable: false),
                        ThirdNumber = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DbPayments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(nullable: false),
                        Month = c.DateTime(nullable: false),
                        TotalPayment = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DbClients", t => t.ClientId, cascadeDelete: true)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.DbSMS",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExternalPrice = c.Double(nullable: false),
                        LineId = c.Int(nullable: false),
                        DestinationNumber = c.String(nullable: false),
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
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DbClientTypes", t => t.ClientTypeId, cascadeDelete: true)
                .Index(t => t.ClientTypeId);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DbUnsignClients", "ClientTypeId", "dbo.DbClientTypes");
            DropForeignKey("dbo.DbSMS", "LineId", "dbo.DbLines");
            DropForeignKey("dbo.DbPayments", "ClientId", "dbo.DbClients");
            DropForeignKey("dbo.DbCalls", "LineId", "dbo.DbLines");
            DropForeignKey("dbo.DbLines", "PackageId", "dbo.DbPackages");
            DropForeignKey("dbo.DbPackages", "SelectedNuberId", "dbo.DbSelectedNumbers");
            DropForeignKey("dbo.DbLines", "ClientId", "dbo.DbClients");
            DropForeignKey("dbo.DbClients", "ClientTypeId", "dbo.DbClientTypes");
            DropIndex("dbo.DbUnsignClients", new[] { "ClientTypeId" });
            DropIndex("dbo.DbSMS", new[] { "LineId" });
            DropIndex("dbo.DbPayments", new[] { "ClientId" });
            DropIndex("dbo.DbPackages", new[] { "SelectedNuberId" });
            DropIndex("dbo.DbClients", new[] { "ClientTypeId" });
            DropIndex("dbo.DbLines", new[] { "PackageId" });
            DropIndex("dbo.DbLines", new[] { "ClientId" });
            DropIndex("dbo.DbCalls", new[] { "LineId" });
            DropTable("dbo.DbUsers");
            DropTable("dbo.DbUnsignClients");
            DropTable("dbo.DbSMS");
            DropTable("dbo.DbPayments");
            DropTable("dbo.DbSelectedNumbers");
            DropTable("dbo.DbPackages");
            DropTable("dbo.DbClientTypes");
            DropTable("dbo.DbClients");
            DropTable("dbo.DbLines");
            DropTable("dbo.DbCalls");
        }
    }
}
