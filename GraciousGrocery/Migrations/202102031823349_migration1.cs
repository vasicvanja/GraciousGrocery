namespace GraciousGrocery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration1 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Products", new[] { "category_CategoryId" });
            AddColumn("dbo.CartItems", "Quantity", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "Category_CategoryId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Products", new[] { "Category_CategoryId" });
            DropColumn("dbo.CartItems", "Quantity");
            CreateIndex("dbo.Products", "category_CategoryId");
        }
    }
}
