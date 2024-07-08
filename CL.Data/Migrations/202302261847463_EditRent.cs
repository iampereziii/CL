namespace CL.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditRent : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rents", "RentDetails_Id", "dbo.RentDetails");
            DropIndex("dbo.Rents", new[] { "RentDetails_Id" });
            CreateTable(
                "dbo.Rentals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateReturned = c.DateTime(nullable: false),
                        DateRented = c.DateTime(nullable: false),
                        Customer_Id = c.Int(),
                        Movie_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .ForeignKey("dbo.Movies", t => t.Movie_Id)
                .Index(t => t.Customer_Id)
                .Index(t => t.Movie_Id);
            
            DropTable("dbo.Rents");
            DropTable("dbo.RentDetails");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RentDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateReturned = c.DateTime(nullable: false),
                        DateRented = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        RentDetails_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Rentals", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.Rentals", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Rentals", new[] { "Movie_Id" });
            DropIndex("dbo.Rentals", new[] { "Customer_Id" });
            DropTable("dbo.Rentals");
            CreateIndex("dbo.Rents", "RentDetails_Id");
            AddForeignKey("dbo.Rents", "RentDetails_Id", "dbo.RentDetails", "Id");
        }
    }
}
