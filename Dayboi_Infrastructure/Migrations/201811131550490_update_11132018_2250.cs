namespace Dayboi_Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_11132018_2250 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pools", "OpeningHour", c => c.Int());
            AddColumn("dbo.Pools", "ClosedHour", c => c.Int());
            AddColumn("dbo.Pools", "OpeningDay", c => c.String());
            DropColumn("dbo.Pools", "OpeningTime");
            DropColumn("dbo.Pools", "ClosedTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pools", "ClosedTime", c => c.DateTime());
            AddColumn("dbo.Pools", "OpeningTime", c => c.DateTime());
            DropColumn("dbo.Pools", "OpeningDay");
            DropColumn("dbo.Pools", "ClosedHour");
            DropColumn("dbo.Pools", "OpeningHour");
        }
    }
}
