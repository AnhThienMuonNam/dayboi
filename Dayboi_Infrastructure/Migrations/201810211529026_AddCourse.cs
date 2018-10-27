namespace Dayboi_Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCourse : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 200),
                        Alias = c.String(maxLength: 200),
                        MetaKeyword = c.String(maxLength: 250),
                        Description = c.String(maxLength: 500),
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
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CourseTags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tag = c.String(maxLength: 200),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
            DropColumn("dbo.Blogs", "RelatedProducts");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Blogs", "RelatedProducts", c => c.String(maxLength: 500));
            DropForeignKey("dbo.CourseTags", "CourseId", "dbo.Courses");
            DropIndex("dbo.CourseTags", new[] { "CourseId" });
            DropTable("dbo.CourseTags");
            DropTable("dbo.Courses");
        }
    }
}
