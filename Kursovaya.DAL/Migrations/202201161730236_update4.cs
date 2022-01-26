namespace Kursovaya.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.KeyWords", "BotUser_Id", "dbo.BotUsers");
            DropIndex("dbo.KeyWords", new[] { "BotUser_Id" });
            CreateTable(
                "dbo.BotUserKeyWords",
                c => new
                    {
                        BotUser_Id = c.Int(nullable: false),
                        KeyWords_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BotUser_Id, t.KeyWords_Id })
                .ForeignKey("dbo.BotUsers", t => t.BotUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.KeyWords", t => t.KeyWords_Id, cascadeDelete: true)
                .Index(t => t.BotUser_Id)
                .Index(t => t.KeyWords_Id);
            
            DropColumn("dbo.KeyWords", "BotUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.KeyWords", "BotUser_Id", c => c.Int());
            DropForeignKey("dbo.BotUserKeyWords", "KeyWords_Id", "dbo.KeyWords");
            DropForeignKey("dbo.BotUserKeyWords", "BotUser_Id", "dbo.BotUsers");
            DropIndex("dbo.BotUserKeyWords", new[] { "KeyWords_Id" });
            DropIndex("dbo.BotUserKeyWords", new[] { "BotUser_Id" });
            DropTable("dbo.BotUserKeyWords");
            CreateIndex("dbo.KeyWords", "BotUser_Id");
            AddForeignKey("dbo.KeyWords", "BotUser_Id", "dbo.BotUsers", "Id");
        }
    }
}
