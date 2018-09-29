namespace Dayboi_Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateBlogv3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "Tags", c => c.String(maxLength: 500));
            AddColumn("dbo.Blogs", "RelatedProducts", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Blogs", "RelatedProducts");
            DropColumn("dbo.Blogs", "Tags");
        }
    }
}
