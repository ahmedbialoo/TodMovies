namespace TodMovies.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class roles : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'62c3829c-e4ae-42ad-871e-fae9b3123fad', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'484d2b2e-44b0-48d5-b020-30f31a705a6f', N'guest@google.com', 0, N'AKfRwLP0W5wKW5WDIzbfRRLLnnHE5f2hxJuVYphHK4kk9KWdNdR5MFlU3UbSF6oElg==', N'd44c492d-db75-44d3-8e9b-cf7756d424a1', NULL, 0, 0, NULL, 1, 0, N'guest@google.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'9453772b-c943-4757-b059-19675b844868', N'admin@google.com', 0, N'AFddYer18BGWsqr3ysUvFUrKpZ9wgVOb/hDiOul/hQRV6saCTGeEFFy7rU+bacRE3g==', N'20682de6-200f-4812-86e3-767d0ec1446e', NULL, 0, 0, NULL, 1, 0, N'admin@google.com')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'9453772b-c943-4757-b059-19675b844868', N'62c3829c-e4ae-42ad-871e-fae9b3123fad')
");
        }

        public override void Down()
        {
        }
    }
}
