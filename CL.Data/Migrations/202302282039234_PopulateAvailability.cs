namespace CL.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateAvailability : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE dbo.Movies SET [StocksAvailable] = [Stocks];");
        }
        
        public override void Down()
        {
        }
    }
}
