namespace CL.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDummyData : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershiptypeModels Values (1,0,0,0)");
            Sql("INSERT INTO MembershiptypeModels Values (2,30,1,10)");
            Sql("INSERT INTO MembershiptypeModels Values (3,90,3,15)");
            Sql("INSERT INTO MembershiptypeModels Values (4,300,12,20)");

            Sql("UPDATE MEMBERSHIPTYPEMODELS set Name ='Pay as You Go' WHERE Id=1");
            Sql("UPDATE MEMBERSHIPTYPEMODELS set Name ='Monthly' WHERE Id=2");
            Sql("UPDATE MEMBERSHIPTYPEMODELS set Name ='Quarterly' WHERE Id=3");
            Sql("UPDATE MEMBERSHIPTYPEMODELS set Name ='Annual' WHERE Id=4");

            Sql("INSERT INTO CustomerDetailsModels Values (convert(datetime,'18-06-95 10:34:09 PM',5))");

            Sql("INSERT INTO GenreModels Values ('Action')");
            Sql("INSERT INTO GenreModels Values ('Comedy')");
            Sql("INSERT INTO GenreModels Values ('Romance')");
            Sql("INSERT INTO GenreModels Values ('Sci-Fi')");
            Sql("INSERT INTO GenreModels Values ('Family')");

        }

        public override void Down()
        {
        }
    }
}
