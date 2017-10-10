namespace AcopioUP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUnitsNeededAndInStockToProductsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "UnitsNeeded", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "UnitsInStock", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "UnitsInStock");
            DropColumn("dbo.Products", "UnitsNeeded");
        }
    }
}
