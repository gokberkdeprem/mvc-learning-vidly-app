namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"

INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'3968f1f9-6981-46ed-a689-afed5efe2f8c', N'guest@vidly.com', 0, N'ABAqfKx7uDW9tGboDPE0GENs1S7nVqtYRCE7MN4nNxWJfLJB3RtAWq17bs9Vm8ondA==', N'cd8500ee-6224-4fc3-a47e-c57e0f92aeea', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'40a5a514-3309-476a-b67e-7395d13a6a51', N'admin@vidly.com', 0, N'AE4DRITfdm+WuGeY24hbewIjQg+k7rSGCd/lh+rkDN8LWUyiq/+vh4xbQ3+JzBg34w==', N'27a502b2-0f3c-452a-8796-060319dcab3f', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'85dfbf93-4f42-4e94-8efc-1699bc942e88', N'as@gmail.com', 0, N'ALGbDNFk1Grs5tdj8qrJLzqV5JNKmrXC/f1zFZocaECdaTXAH0ngA+IV/RURDW0Gdg==', N'49be66df-298d-42d5-8b8c-d37871e04099', NULL, 0, 0, NULL, 1, 0, N'as@gmail.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'7231c902-3163-4b89-9609-4acaf1addfc3', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'40a5a514-3309-476a-b67e-7395d13a6a51', N'7231c902-3163-4b89-9609-4acaf1addfc3')
");
        }
        
        public override void Down()
        {
        }
    }
}
