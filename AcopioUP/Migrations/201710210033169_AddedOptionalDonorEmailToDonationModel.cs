namespace AcopioUP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedOptionalDonorEmailToDonationModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Donations", "DonorEmail", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Donations", "DonorEmail");
        }
    }
}
