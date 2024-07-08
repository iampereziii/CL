namespace CL.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RentTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        customers_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.customers_Id)
                .Index(t => t.customers_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rents", "customers_Id", "dbo.Customers");
            DropIndex("dbo.Rents", new[] { "customers_Id" });
            DropTable("dbo.Rents");
        }
    }
}
