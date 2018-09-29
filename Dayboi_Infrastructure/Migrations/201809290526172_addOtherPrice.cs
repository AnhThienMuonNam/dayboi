namespace Dayboi_Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addOtherPrice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "OtherPrice", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "OtherPrice");
        }
    }
}
