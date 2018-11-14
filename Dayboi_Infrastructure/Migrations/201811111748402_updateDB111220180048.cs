namespace Dayboi_Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDB111220180048 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EnrollmentCourses", "StartDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EnrollmentCourses", "StartDate", c => c.DateTime(nullable: false));
        }
    }
}
