namespace AcopioUP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveUserIdFromAddress : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Addresses", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Addresses", "UserId", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
