namespace AcopioUP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyAnnotationsToProduct : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Products", "ImgSrc", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "ImgSrc", c => c.String());
            AlterColumn("dbo.Products", "Name", c => c.String());
        }
    }
}
