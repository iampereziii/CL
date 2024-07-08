namespace CL.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TableEdits : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Movies", newName: "Movies");
            AddColumn("dbo.AspNetUsers", "DriversLicense", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "DriversLicense");
            RenameTable(name: "dbo.Movies", newName: "Movies");
        }
    }
}
