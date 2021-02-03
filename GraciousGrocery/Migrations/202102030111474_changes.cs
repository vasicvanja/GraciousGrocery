namespace GraciousGrocery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Description", c => c.String(nullable: false));
            DropColumn("dbo.Products", "Weight");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Weight", c => c.Single(nullable: false));
            DropColumn("dbo.Products", "Description");
        }
    }
}
