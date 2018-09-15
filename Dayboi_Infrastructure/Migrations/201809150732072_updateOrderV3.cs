namespace Dayboi_Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateOrderV3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Note", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "Note");
        }
    }
}
