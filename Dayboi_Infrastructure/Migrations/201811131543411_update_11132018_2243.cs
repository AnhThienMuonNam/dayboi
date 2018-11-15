namespace Dayboi_Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_11132018_2243 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pools", "OpeningTime", c => c.DateTime());
            AddColumn("dbo.Pools", "ClosedTime", c => c.DateTime());
            AddColumn("dbo.Pools", "Fare", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pools", "Fare");
            DropColumn("dbo.Pools", "ClosedTime");
            DropColumn("dbo.Pools", "OpeningTime");
        }
    }
}
