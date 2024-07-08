namespace CL.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameModels : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CustomerModels", newName: "Customers");
            RenameTable(name: "dbo.CustomerDetailsModels", newName: "CustomerDetails");
            RenameTable(name: "dbo.MembershipTypeModels", newName: "MembershipTypes");
            RenameTable(name: "dbo.GenreModels", newName: "Genres");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Genres", newName: "GenreModels");
            RenameTable(name: "dbo.MembershipTypes", newName: "MembershipTypeModels");
            RenameTable(name: "dbo.CustomerDetails", newName: "CustomerDetailsModels");
            RenameTable(name: "dbo.Customers", newName: "CustomerModels");
        }
    }
}
