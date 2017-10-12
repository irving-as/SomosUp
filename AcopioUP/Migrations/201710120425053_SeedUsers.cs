namespace AcopioUP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'081c4be1-e8b0-4d45-a051-2728a88c81c2', N'admin@up.edu.mx', 0, N'AHKBY+9JRT1QVuJRFswdZ/574puCdTzk1TC9qOLHMudgKJuzCLuZMkR/4SyEfBPWDQ==', N'd926228f-b243-4002-b4e3-1823244dbe27', NULL, 0, 0, NULL, 1, 0, N'admin@up.edu.mx')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'ee0cb486-37de-4124-8650-c0caabfec2e8', N'CanManageProducts')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'b2dd827c-5296-4530-bf27-118550488871', N'CanManageVictims')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'081c4be1-e8b0-4d45-a051-2728a88c81c2', N'b2dd827c-5296-4530-bf27-118550488871')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'081c4be1-e8b0-4d45-a051-2728a88c81c2', N'ee0cb486-37de-4124-8650-c0caabfec2e8')
");
        }
        
        public override void Down()
        {
        }
    }
}
