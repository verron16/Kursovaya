namespace Kursovaya.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateStates : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BotUsers", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BotUsers", "Status", c => c.String());
        }
    }
}
