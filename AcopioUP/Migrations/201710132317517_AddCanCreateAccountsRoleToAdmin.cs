namespace AcopioUP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCanCreateAccountsRoleToAdmin : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'081c4be1-e8b0-4d45-a051-2728a88c81c2', N'efc666a0-51a0-47cf-ad21-4f8a15689563')
");
        }
        
        public override void Down()
        {
        }
    }
}
