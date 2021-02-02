namespace GraciousGrocery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class shoppingCart_submitedProducts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShoppingCartModels",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.SubmitedProducts",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId);
            
            AddColumn("dbo.Products", "ShoppingCartModel_UserId", c => c.String(maxLength: 128));
            AddColumn("dbo.Products", "SubmitedProducts_UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Products", "ShoppingCartModel_UserId");
            CreateIndex("dbo.Products", "SubmitedProducts_UserId");
            AddForeignKey("dbo.Products", "ShoppingCartModel_UserId", "dbo.ShoppingCartModels", "UserId");
            AddForeignKey("dbo.Products", "SubmitedProducts_UserId", "dbo.SubmitedProducts", "UserId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "SubmitedProducts_UserId", "dbo.SubmitedProducts");
            DropForeignKey("dbo.Products", "ShoppingCartModel_UserId", "dbo.ShoppingCartModels");
            DropIndex("dbo.Products", new[] { "SubmitedProducts_UserId" });
            DropIndex("dbo.Products", new[] { "ShoppingCartModel_UserId" });
            DropColumn("dbo.Products", "SubmitedProducts_UserId");
            DropColumn("dbo.Products", "ShoppingCartModel_UserId");
            DropTable("dbo.SubmitedProducts");
            DropTable("dbo.ShoppingCartModels");
        }
    }
}
