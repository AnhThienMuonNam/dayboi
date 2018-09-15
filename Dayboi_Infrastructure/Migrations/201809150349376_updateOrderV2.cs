namespace Dayboi_Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateOrderV2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "ProvinceName", c => c.String(maxLength: 50));
            AddColumn("dbo.Orders", "DistrictName", c => c.String(maxLength: 50));
            AddColumn("dbo.Orders", "WardName", c => c.String(maxLength: 50));
            AddColumn("dbo.Orders", "ProvinceId", c => c.Int());
            AddColumn("dbo.Orders", "DistrictId", c => c.Int());
            AddColumn("dbo.Orders", "WardId", c => c.Int());
            AddColumn("dbo.Orders", "ShippingFee", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Orders", "Address", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "Address", c => c.String(maxLength: 1000));
            DropColumn("dbo.Orders", "ShippingFee");
            DropColumn("dbo.Orders", "WardId");
            DropColumn("dbo.Orders", "DistrictId");
            DropColumn("dbo.Orders", "ProvinceId");
            DropColumn("dbo.Orders", "WardName");
            DropColumn("dbo.Orders", "DistrictName");
            DropColumn("dbo.Orders", "ProvinceName");
        }
    }
}
