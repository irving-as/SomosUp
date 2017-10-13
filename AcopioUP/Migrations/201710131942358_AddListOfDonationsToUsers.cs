namespace AcopioUP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddListOfDonationsToUsers : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Donations", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Donations", "UserId");
            AddForeignKey("dbo.Donations", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Donations", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Donations", new[] { "UserId" });
            AlterColumn("dbo.Donations", "UserId", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
