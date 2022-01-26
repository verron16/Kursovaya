namespace Kursovaya.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.KeyWords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KeyWord = c.String(),
                        BotUser_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BotUsers", t => t.BotUser_Id)
                .Index(t => t.BotUser_Id);
            
            CreateTable(
                "dbo.BotUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TId = c.Long(nullable: false),
                        Name = c.String(),
                        Status = c.String(),
                        FirstDate = c.DateTime(nullable: false),
                        NotificationHour = c.Int(nullable: false),
                        Banned = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.KeyWords", "BotUser_Id", "dbo.BotUsers");
            DropIndex("dbo.KeyWords", new[] { "BotUser_Id" });
            DropTable("dbo.BotUsers");
            DropTable("dbo.KeyWords");
        }
    }
}
