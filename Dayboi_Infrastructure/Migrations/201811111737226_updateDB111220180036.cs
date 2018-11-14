namespace Dayboi_Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDB111220180036 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.OrderStatuses", newName: "OrderStatues");
            CreateTable(
                "dbo.EnrollmentCourseStatues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        IsDeleted = c.Boolean(nullable: false),
                        DisplayOrder = c.Int(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.EnrollmentCourses", "EnrollmentCourseStatusId", c => c.Int(nullable: false));
            CreateIndex("dbo.EnrollmentCourses", "EnrollmentCourseStatusId");
            AddForeignKey("dbo.EnrollmentCourses", "EnrollmentCourseStatusId", "dbo.EnrollmentCourseStatues", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EnrollmentCourses", "EnrollmentCourseStatusId", "dbo.EnrollmentCourseStatues");
            DropIndex("dbo.EnrollmentCourses", new[] { "EnrollmentCourseStatusId" });
            DropColumn("dbo.EnrollmentCourses", "EnrollmentCourseStatusId");
            DropTable("dbo.EnrollmentCourseStatues");
            RenameTable(name: "dbo.OrderStatues", newName: "OrderStatuses");
        }
    }
}
