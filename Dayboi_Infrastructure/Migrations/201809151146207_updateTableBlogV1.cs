namespace Dayboi_Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateTableBlogV1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BlogCategories", "Alias", c => c.String(maxLength: 200));
            AddColumn("dbo.BlogCategories", "MetaKeyword", c => c.String(maxLength: 250));
            AddColumn("dbo.Blogs", "Alias", c => c.String(maxLength: 200));
            AddColumn("dbo.Blogs", "MetaKeyword", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Blogs", "MetaKeyword");
            DropColumn("dbo.Blogs", "Alias");
            DropColumn("dbo.BlogCategories", "MetaKeyword");
            DropColumn("dbo.BlogCategories", "Alias");
        }
    }
}
