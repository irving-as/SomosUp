namespace AcopioUP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedProductFieldInDonationModel : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Donations", "ProductId");
            AddForeignKey("dbo.Donations", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Donations", "ProductId", "dbo.Products");
            DropIndex("dbo.Donations", new[] { "ProductId" });
        }
    }
}
