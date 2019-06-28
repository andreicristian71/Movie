namespace Movie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'367c770f-0589-4e03-891f-67a71cf2c641', N'admin@movie.com', 0, N'ALHdM8gEBCmZLR7UrZOTy68DI5j6da0+vcqcbwREEpNuEuCzrtAvT0lo4+FFrWheJQ==', N'6677b534-e996-47d8-b804-e91f0577ffbe', NULL, 0, 0, NULL, 1, 0, N'admin@movie.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b902d270-7d21-49ba-a930-135d9957ab85', N'guest@movie.com', 0, N'AAWkFQ5qR8LdkCIS0+ggxHpZ5PaRIwB6kLzVgsohpOr/wPLpOFzTPTgQUfQo0ac4iQ==', N'58df0c2a-842c-4fe7-834d-f606c9224fb7', NULL, 0, 0, NULL, 1, 0, N'guest@movie.com')
            
            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'6f79b5af-87e6-4350-9818-9ea48899517a', N'CanManageMovies')
            
            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'367c770f-0589-4e03-891f-67a71cf2c641', N'6f79b5af-87e6-4350-9818-9ea48899517a')");
        }
        
        public override void Down()
        {
        }
    }
}
