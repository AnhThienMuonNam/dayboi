namespace Dayboi_Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTableOrder : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductName = c.String(maxLength: 100),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SumPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        Email = c.String(maxLength: 100),
                        Phone = c.String(maxLength: 50),
                        Address = c.String(maxLength: 1000),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderStatusId = c.Int(nullable: false),
                        PaymentMethodId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedBy = c.String(maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUsers", t => t.CreatedBy)
                .ForeignKey("dbo.OrderStatuses", t => t.OrderStatusId, cascadeDelete: true)
                .ForeignKey("dbo.PaymentMethods", t => t.PaymentMethodId)
                .ForeignKey("dbo.ApplicationUsers", t => t.UpdatedBy)
                .Index(t => t.OrderStatusId)
                .Index(t => t.PaymentMethodId)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy);
            
            CreateTable(
                "dbo.OrderStatuses",
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
                "dbo.PaymentMethods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        IsDeleted = c.Boolean(nullable: false),
                        DisplayOrder = c.Int(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Orders", "UpdatedBy", "dbo.ApplicationUsers");
            DropForeignKey("dbo.Orders", "PaymentMethodId", "dbo.PaymentMethods");
            DropForeignKey("dbo.Orders", "OrderStatusId", "dbo.OrderStatuses");
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "CreatedBy", "dbo.ApplicationUsers");
            DropIndex("dbo.Orders", new[] { "UpdatedBy" });
            DropIndex("dbo.Orders", new[] { "CreatedBy" });
            DropIndex("dbo.Orders", new[] { "PaymentMethodId" });
            DropIndex("dbo.Orders", new[] { "OrderStatusId" });
            DropIndex("dbo.OrderDetails", new[] { "ProductId" });
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            DropTable("dbo.PaymentMethods");
            DropTable("dbo.OrderStatuses");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
        }
    }
}
