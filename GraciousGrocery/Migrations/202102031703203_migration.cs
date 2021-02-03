namespace GraciousGrocery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "CartItem_UserId", "dbo.CartItems");
            DropIndex("dbo.Products", new[] { "CartItem_UserId" });
            RenameColumn(table: "dbo.Products", name: "CartItem_UserId", newName: "CartItem_ProductId");
            DropPrimaryKey("dbo.CartItems");
            AddColumn("dbo.CartItems", "ProductId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.CartItems", "UserId", c => c.String());
            AlterColumn("dbo.Products", "CartItem_ProductId", c => c.Int());
            AddPrimaryKey("dbo.CartItems", "ProductId");
            CreateIndex("dbo.Products", "CartItem_ProductId");
            AddForeignKey("dbo.Products", "CartItem_ProductId", "dbo.CartItems", "ProductId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "CartItem_ProductId", "dbo.CartItems");
            DropIndex("dbo.Products", new[] { "CartItem_ProductId" });
            DropPrimaryKey("dbo.CartItems");
            AlterColumn("dbo.Products", "CartItem_ProductId", c => c.String(maxLength: 128));
            AlterColumn("dbo.CartItems", "UserId", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.CartItems", "ProductId");
            AddPrimaryKey("dbo.CartItems", "UserId");
            RenameColumn(table: "dbo.Products", name: "CartItem_ProductId", newName: "CartItem_UserId");
            CreateIndex("dbo.Products", "CartItem_UserId");
            AddForeignKey("dbo.Products", "CartItem_UserId", "dbo.CartItems", "UserId");
        }
    }
}
