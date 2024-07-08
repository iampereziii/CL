namespace CL.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class EnterRoles : DbMigration
    {
        public override void Up()
        {
            Sql(@" INSERT INTO[dbo].[AspNetRoles] ([Id], [Name]) VALUES(N'8e533a92-3de5-4b92-affa-c2d923c3e1f6', N'CanEditMovie')");

            Sql(@"  INSERT INTO[dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES(N'bc4fcb81-6f3a-4542-baeb-ba26e204ac0b', N'8e533a92-3de5-4b92-affa-c2d923c3e1f6')");

        }

        public override void Down()
        {
        }
    }
}
