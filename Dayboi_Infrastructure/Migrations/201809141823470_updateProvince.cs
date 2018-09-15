namespace Dayboi_Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateProvince : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Provinces", "Type", c => c.String(maxLength: 50));
            AddColumn("dbo.Provinces", "ZipCode", c => c.String(maxLength: 20));
            AddColumn("dbo.Provinces", "CountryId", c => c.Int(nullable: false));
            AddColumn("dbo.Provinces", "CountryCode", c => c.String(maxLength: 5));
            AddColumn("dbo.Provinces", "TelephoneCode", c => c.Int(nullable: false));
            AddColumn("dbo.Provinces", "IsPublished", c => c.Boolean(nullable: false));
            DropColumn("dbo.Provinces", "IsActive");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Provinces", "IsActive", c => c.Boolean(nullable: false));
            DropColumn("dbo.Provinces", "IsPublished");
            DropColumn("dbo.Provinces", "TelephoneCode");
            DropColumn("dbo.Provinces", "CountryCode");
            DropColumn("dbo.Provinces", "CountryId");
            DropColumn("dbo.Provinces", "ZipCode");
            DropColumn("dbo.Provinces", "Type");
        }
    }
}
