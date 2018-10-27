namespace Dayboi_Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDBv12 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pools", "PoolCategory_Id", "dbo.PoolCategories");
            DropIndex("dbo.Pools", new[] { "PoolCategory_Id" });
            RenameColumn(table: "dbo.Pools", name: "PoolCategory_Id", newName: "PoolCategoryId");
            AlterColumn("dbo.Pools", "PoolCategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Pools", "PoolCategoryId");
            AddForeignKey("dbo.Pools", "PoolCategoryId", "dbo.PoolCategories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pools", "PoolCategoryId", "dbo.PoolCategories");
            DropIndex("dbo.Pools", new[] { "PoolCategoryId" });
            AlterColumn("dbo.Pools", "PoolCategoryId", c => c.Int());
            RenameColumn(table: "dbo.Pools", name: "PoolCategoryId", newName: "PoolCategory_Id");
            CreateIndex("dbo.Pools", "PoolCategory_Id");
            AddForeignKey("dbo.Pools", "PoolCategory_Id", "dbo.PoolCategories", "Id");
        }
    }
}
