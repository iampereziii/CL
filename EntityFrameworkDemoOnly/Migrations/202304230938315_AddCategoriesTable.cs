namespace EntityFrameworkDemoOnly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoriesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);

            Sql("insert into categories (name) values ('test')");
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Categories");
        }
    }
}
