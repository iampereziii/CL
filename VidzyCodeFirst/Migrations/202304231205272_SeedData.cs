namespace VidzyCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedData : DbMigration
    {
        public override void Up()
        {
            Sql(
                @"INSERT INTO [dbo].[Genres] ([Name]) VALUES ( N'Comedy')
                INSERT INTO [dbo].[Genres] ([Name]) VALUES ( N'Action')
                INSERT INTO [dbo].[Genres] ([Name]) VALUES ( N'Romance')
                INSERT INTO [dbo].[Genres] ([Name]) VALUES (N'SciFi')"
            );


        }

        public override void Down()
        {
        }
    }
}
