namespace Dayboi_Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addEnrollment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EnrollmentCourses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(maxLength: 200),
                        Phone = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        Note = c.String(maxLength: 200),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(),
                        CreatedBy = c.String(),
                        UpdatedBy = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        CourseId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.ApplicationUsers", t => t.UserId)
                .Index(t => t.CourseId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EnrollmentCourses", "UserId", "dbo.ApplicationUsers");
            DropForeignKey("dbo.EnrollmentCourses", "CourseId", "dbo.Courses");
            DropIndex("dbo.EnrollmentCourses", new[] { "UserId" });
            DropIndex("dbo.EnrollmentCourses", new[] { "CourseId" });
            DropTable("dbo.EnrollmentCourses");
        }
    }
}
