namespace AcopioUP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDonations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Donations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Units = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Description = c.String(maxLength: 255),
                        UserId = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Donations");
        }
    }
}
