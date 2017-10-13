namespace AcopioUP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewRoles : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'efc666a0-51a0-47cf-ad21-4f8a15689563', N'CanCreateAccounts')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'9c8a6291-0917-42d4-b89b-c7e2d819e6b3', N'CanManageDonations')
");
        }
        
        public override void Down()
        {
        }
    }
}
