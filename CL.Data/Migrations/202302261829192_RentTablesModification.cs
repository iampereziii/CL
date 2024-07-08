namespace CL.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RentTablesModification : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rents", "customers_Id", "dbo.Customers");
            DropIndex("dbo.Rents", new[] { "customers_Id" });
            AddColumn("dbo.Rents", "CustomerId", c => c.Int(nullable: false));
            DropColumn("dbo.Rents", "customers_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rents", "customers_Id", c => c.Int());
            DropColumn("dbo.Rents", "CustomerId");
            CreateIndex("dbo.Rents", "customers_Id");
            AddForeignKey("dbo.Rents", "customers_Id", "dbo.Customers", "Id");
        }
    }
}
