namespace Dayboi_Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPoolTabl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PoolCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Alias = c.String(maxLength: 200),
                        MetaKeyword = c.String(maxLength: 250),
                        Image = c.String(maxLength: 500),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(),
                        CreatedBy = c.String(),
                        UpdatedBy = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        DisplayOrder = c.Int(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pools",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 200),
                        Alias = c.String(maxLength: 200),
                        MetaKeyword = c.String(maxLength: 250),
                        Address = c.String(maxLength: 500),
                        Content = c.String(),
                        ViewCount = c.Int(),
                        Image = c.String(maxLength: 200),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(),
                        CreatedBy = c.String(),
                        UpdatedBy = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        DisplayOrder = c.Int(),
                        IsActive = c.Boolean(nullable: false),
                        PoolCategory_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PoolCategories", t => t.PoolCategory_Id)
                .Index(t => t.PoolCategory_Id);
            
            CreateTable(
                "dbo.PoolTags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tag = c.String(maxLength: 200),
                        PoolId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pools", t => t.PoolId, cascadeDelete: true)
                .Index(t => t.PoolId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pools", "PoolCategory_Id", "dbo.PoolCategories");
            DropForeignKey("dbo.PoolTags", "PoolId", "dbo.Pools");
            DropIndex("dbo.PoolTags", new[] { "PoolId" });
            DropIndex("dbo.Pools", new[] { "PoolCategory_Id" });
            DropTable("dbo.PoolTags");
            DropTable("dbo.Pools");
            DropTable("dbo.PoolCategories");
        }
    }
}
