namespace Eferada.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSubjectTestTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SubjectTest",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        CourseId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                        Term = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Course", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Subject", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.CourseId)
                .Index(t => t.SubjectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubjectTest", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.SubjectTest", "CourseId", "dbo.Course");
            DropIndex("dbo.SubjectTest", new[] { "SubjectId" });
            DropIndex("dbo.SubjectTest", new[] { "CourseId" });
            DropTable("dbo.SubjectTest");
        }
    }
}
