namespace Dayboi_Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTableSkill : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Skills",
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
                "dbo.SkillTags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tag = c.String(maxLength: 200),
                        SkillId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Skills", t => t.SkillId, cascadeDelete: true)
                .Index(t => t.SkillId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SkillTags", "SkillId", "dbo.Skills");
            DropIndex("dbo.SkillTags", new[] { "SkillId" });
            DropTable("dbo.SkillTags");
            DropTable("dbo.Skills");
        }
    }
}
