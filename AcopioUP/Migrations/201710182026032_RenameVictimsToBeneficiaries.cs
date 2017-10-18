namespace AcopioUP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameVictimsToBeneficiaries : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Victims", newName: "Beneficiaries");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Beneficiaries", newName: "Victims");
        }
    }
}
