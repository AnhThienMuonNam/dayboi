namespace Dayboi_Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTableAddress : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Districts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        IsDeleted = c.Boolean(nullable: false),
                        DisplayOrder = c.Int(),
                        IsActive = c.Boolean(nullable: false),
                        ProvinceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Provinces", t => t.ProvinceId, cascadeDelete: true)
                .Index(t => t.ProvinceId);
            
            CreateTable(
                "dbo.Provinces",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        IsDeleted = c.Boolean(nullable: false),
                        DisplayOrder = c.Int(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Wards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        IsDeleted = c.Boolean(nullable: false),
                        DisplayOrder = c.Int(),
                        IsActive = c.Boolean(nullable: false),
                        DistrictId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Districts", t => t.DistrictId, cascadeDelete: true)
                .Index(t => t.DistrictId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Wards", "DistrictId", "dbo.Districts");
            DropForeignKey("dbo.Districts", "ProvinceId", "dbo.Provinces");
            DropIndex("dbo.Wards", new[] { "DistrictId" });
            DropIndex("dbo.Districts", new[] { "ProvinceId" });
            DropTable("dbo.Wards");
            DropTable("dbo.Provinces");
            DropTable("dbo.Districts");
        }
    }
}
