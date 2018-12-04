namespace Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DbPayments", "ClientId", "dbo.DbClients");
            DropIndex("dbo.DbPayments", new[] { "ClientId" });
            RenameColumn(table: "dbo.DbPackages", name: "SelectedNuberId", newName: "SelectedNumberId");
            RenameIndex(table: "dbo.DbPackages", name: "IX_SelectedNuberId", newName: "IX_SelectedNumberId");
            AddColumn("dbo.DbPackages", "MaxSMSs", c => c.Int(nullable: false));
            AddColumn("dbo.DbPayments", "LineId", c => c.Int(nullable: false));
            AlterColumn("dbo.DbPackages", "DisscountPrecentage", c => c.Int(nullable: false));
            CreateIndex("dbo.DbPayments", "LineId");
            AddForeignKey("dbo.DbPayments", "LineId", "dbo.DbLines", "Id", cascadeDelete: true);
            DropColumn("dbo.DbPayments", "ClientId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DbPayments", "ClientId", c => c.Int(nullable: false));
            DropForeignKey("dbo.DbPayments", "LineId", "dbo.DbLines");
            DropIndex("dbo.DbPayments", new[] { "LineId" });
            AlterColumn("dbo.DbPackages", "DisscountPrecentage", c => c.Double(nullable: false));
            DropColumn("dbo.DbPayments", "LineId");
            DropColumn("dbo.DbPackages", "MaxSMSs");
            RenameIndex(table: "dbo.DbPackages", name: "IX_SelectedNumberId", newName: "IX_SelectedNuberId");
            RenameColumn(table: "dbo.DbPackages", name: "SelectedNumberId", newName: "SelectedNuberId");
            CreateIndex("dbo.DbPayments", "ClientId");
            AddForeignKey("dbo.DbPayments", "ClientId", "dbo.DbClients", "Id", cascadeDelete: true);
        }
    }
}
