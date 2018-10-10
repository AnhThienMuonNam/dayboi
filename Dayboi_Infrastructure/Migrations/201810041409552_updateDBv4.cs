namespace Dayboi_Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDBv4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlogTags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tag = c.String(maxLength: 200),
                        BlogId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Blogs", t => t.BlogId, cascadeDelete: true)
                .Index(t => t.BlogId);
            
            CreateTable(
                "dbo.ProductTags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tag = c.String(maxLength: 200),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            DropColumn("dbo.Blogs", "Tags");
            DropColumn("dbo.Products", "Tags");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Tags", c => c.String(maxLength: 250));
            AddColumn("dbo.Blogs", "Tags", c => c.String(maxLength: 500));
            DropForeignKey("dbo.ProductTags", "ProductId", "dbo.Products");
            DropForeignKey("dbo.BlogTags", "BlogId", "dbo.Blogs");
            DropIndex("dbo.ProductTags", new[] { "ProductId" });
            DropIndex("dbo.BlogTags", new[] { "BlogId" });
            DropTable("dbo.ProductTags");
            DropTable("dbo.BlogTags");
        }
    }
}
