namespace CL.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRentDetails : DbMigration
    {
        public override void Up()
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
            
            AddColumn("dbo.Rents", "RentDetails_Id", c => c.Int());
            CreateIndex("dbo.Rents", "RentDetails_Id");
            AddForeignKey("dbo.Rents", "RentDetails_Id", "dbo.RentDetails", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rents", "RentDetails_Id", "dbo.RentDetails");
            DropIndex("dbo.Rents", new[] { "RentDetails_Id" });
            DropColumn("dbo.Rents", "RentDetails_Id");
            DropTable("dbo.RentDetails");
        }
    }
}
