namespace Dayboi_Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDistrict : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Districts", "Type", c => c.String(maxLength: 100));
            AddColumn("dbo.Districts", "LatiLongTude", c => c.String(maxLength: 100));
            AddColumn("dbo.Districts", "IsPublished", c => c.Boolean(nullable: false));
            DropColumn("dbo.Districts", "IsActive");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Districts", "IsActive", c => c.Boolean(nullable: false));
            DropColumn("dbo.Districts", "IsPublished");
            DropColumn("dbo.Districts", "LatiLongTude");
            DropColumn("dbo.Districts", "Type");
        }
    }
}
