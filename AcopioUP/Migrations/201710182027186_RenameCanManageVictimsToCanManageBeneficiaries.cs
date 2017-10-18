namespace AcopioUP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameCanManageVictimsToCanManageBeneficiaries : DbMigration
    {
        public override void Up()
        {
            Sql(@"
UPDATE [dbo].[AspNetRoles] SET [Name] = N'CanManageBeneficiaries' WHERE [Id] = N'b2dd827c-5296-4530-bf27-118550488871'
");
        }
        
        public override void Down()
        {
        }
    }
}
