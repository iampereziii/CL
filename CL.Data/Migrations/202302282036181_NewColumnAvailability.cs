namespace CL.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewColumnAvailability : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "StocksAvailable", c => c.Int(nullable: false));
           
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "StocksAvailable");
        }
    }
}
