namespace AcopioUP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCollectionCentersModel : DbMigration
    {
        public override void Up()
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CollectionCenters");
        }
    }
}
