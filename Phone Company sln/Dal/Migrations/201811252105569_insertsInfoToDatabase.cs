namespace Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class insertsInfoToDatabase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DbCalls", "CallDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.DbClients", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.DbSMS", "SmsDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.DbUnsignClients", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.DbClients", "UserId");
            CreateIndex("dbo.DbUnsignClients", "UserId");
            AddForeignKey("dbo.DbClients", "UserId", "dbo.DbUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DbUnsignClients", "UserId", "dbo.DbUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DbUnsignClients", "UserId", "dbo.DbUsers");
            DropForeignKey("dbo.DbClients", "UserId", "dbo.DbUsers");
            DropIndex("dbo.DbUnsignClients", new[] { "UserId" });
            DropIndex("dbo.DbClients", new[] { "UserId" });
            DropColumn("dbo.DbUnsignClients", "UserId");
            DropColumn("dbo.DbSMS", "SmsDate");
            DropColumn("dbo.DbClients", "UserId");
            DropColumn("dbo.DbCalls", "CallDate");
        }
    }
}
