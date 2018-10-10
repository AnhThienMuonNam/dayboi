namespace Dayboi_Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDBv41 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Blogs", "BlogCategoryId", "dbo.BlogCategories");
            DropIndex("dbo.Blogs", new[] { "BlogCategoryId" });
            DropColumn("dbo.Blogs", "BlogCategoryId");
            DropTable("dbo.BlogCategories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.BlogCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 200),
                        Alias = c.String(maxLength: 200),
                        MetaKeyword = c.String(maxLength: 250),
                        ViewCount = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(),
                        CreatedBy = c.String(),
                        UpdatedBy = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        DisplayOrder = c.Int(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Blogs", "BlogCategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Blogs", "BlogCategoryId");
            AddForeignKey("dbo.Blogs", "BlogCategoryId", "dbo.BlogCategories", "Id", cascadeDelete: true);
        }
    }
}
