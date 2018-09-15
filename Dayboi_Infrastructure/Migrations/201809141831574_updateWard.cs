namespace Dayboi_Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateWard : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Wards", "Type", c => c.String(maxLength: 100));
            AddColumn("dbo.Wards", "LatiLongTude", c => c.String(maxLength: 100));
            AddColumn("dbo.Wards", "IsPublished", c => c.Boolean(nullable: false));
            DropColumn("dbo.Wards", "IsActive");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Wards", "IsActive", c => c.Boolean(nullable: false));
            DropColumn("dbo.Wards", "IsPublished");
            DropColumn("dbo.Wards", "LatiLongTude");
            DropColumn("dbo.Wards", "Type");
        }
    }
}
