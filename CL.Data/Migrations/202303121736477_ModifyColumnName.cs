namespace CL.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyColumnName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "StocksAvaivailable", c => c.Int(nullable: false));
            DropColumn("dbo.Movies", "StocksAvailable");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "StocksAvailable", c => c.Int(nullable: false));
            DropColumn("dbo.Movies", "StocksAvaivailable");
        }
    }
}
