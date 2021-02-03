namespace GraciousGrocery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newShoppingCart : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "ShoppingCartModel_UserId", "dbo.ShoppingCartModels");
            DropIndex("dbo.Products", new[] { "ShoppingCartModel_UserId" });
            CreateTable(
                "dbo.CartItems",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId);
            
            AddColumn("dbo.Products", "CartItem_UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Products", "CartItem_UserId");
            AddForeignKey("dbo.Products", "CartItem_UserId", "dbo.CartItems", "UserId");
            DropColumn("dbo.Products", "ShoppingCartModel_UserId");
            DropTable("dbo.ShoppingCartModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ShoppingCartModels",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId);
            
            AddColumn("dbo.Products", "ShoppingCartModel_UserId", c => c.String(maxLength: 128));
            DropForeignKey("dbo.Products", "CartItem_UserId", "dbo.CartItems");
            DropIndex("dbo.Products", new[] { "CartItem_UserId" });
            DropColumn("dbo.Products", "CartItem_UserId");
            DropTable("dbo.CartItems");
            CreateIndex("dbo.Products", "ShoppingCartModel_UserId");
            AddForeignKey("dbo.Products", "ShoppingCartModel_UserId", "dbo.ShoppingCartModels", "UserId");
        }
    }
}
