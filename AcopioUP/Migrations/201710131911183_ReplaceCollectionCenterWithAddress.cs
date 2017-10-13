namespace AcopioUP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReplaceCollectionCenterWithAddress : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StreetAddress = c.String(nullable: false, maxLength: 255),
                        Lat = c.Double(nullable: false),
                        Long = c.Double(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.CollectionCenters");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CollectionCenters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        PhoneNumber = c.String(),
                        Address = c.String(nullable: false, maxLength: 255),
                        Lat = c.Double(nullable: false),
                        Long = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.Addresses");
        }
    }
}
