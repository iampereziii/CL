namespace CL.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddTestUsers : DbMigration
    {
        public override void Up()
        {
            Sql(
                @"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'0d046fee-3b40-4c96-a284-ec032888eadb', N'test@mailinator.com', 0, N'ADDJIDjO2h1pnQb1FYCjfSlihnAjEmscqTO4coadQbQfUo8ZZK/w9rtsnJCIWzfjnw==', N'b008eb6f-fbbc-449f-9e16-d1e7224600ca', NULL, 0, 0, NULL, 1, 0, N'test@mailinator.com');

            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'4617b066-5192-4046-8882-7bcdf7957daa', N'iampereziii@gmail.com', 0, N'ALz4KTK9qfObQHZC3iaM4+mJisSoG7tA/u0PQhFtb+aU2e9lkr136Ze9zWCT5HyVfQ==', N'c83ad66d-f748-4d6f-8e5d-a929ba13aaa9', NULL, 0, 0, NULL, 1, 0, N'iampereziii@gmail.com');

            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'bc4fcb81-6f3a-4542-baeb-ba26e204ac0b', N'admin@mailinator.com', 0, N'AM/HRR7yL55ipuKUtacIqJEvPPP4glAw8qQO79m+1xQo8tX9oXTP/zoJhvGXB2W6BQ==', N'c588c94c-84b7-474e-92f4-5aa2396c1c19', NULL, 0, 0, NULL, 1, 0, N'admin@mailinator.com');
            ");

            Sql("UPDATE dbo.AspNetUsers SET PhoneNumber=''");

        }

        public override void Down()
        {
        }
    }
}
