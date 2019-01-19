namespace Eferada.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStudentAndSubjectTableAndSubjectCourseTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        AcademicYear = c.Int(nullable: false),
                        StudentCardCode = c.String(nullable: false, maxLength: 64, unicode: false),
                        CourseId = c.Int(nullable: false),
                        BirthDateTime = c.DateTime(nullable: false),
                        EnrollmentYear = c.DateTime(nullable: false),
                        StudentStatus = c.Int(nullable: false),
                        Address = c.String(nullable: false, maxLength: 64, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Course", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Subject",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ECTSNumber = c.Int(nullable: false),
                        ProfessorName = c.String(nullable: false, maxLength: 64, unicode: false),
                        Name = c.String(nullable: false, maxLength: 64, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SubjectCourse",
                c => new
                    {
                        SubjectId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SubjectId, t.CourseId })
                .ForeignKey("dbo.Subject", t => t.SubjectId, cascadeDelete: true)
                .ForeignKey("dbo.Course", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.SubjectId)
                .Index(t => t.CourseId);
            
            AddForeignKey("dbo.Users", "Id", "dbo.Student", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubjectCourse", "CourseId", "dbo.Course");
            DropForeignKey("dbo.SubjectCourse", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.Student", "CourseId", "dbo.Course");
            DropForeignKey("dbo.Users", "Id", "dbo.Student");
            DropIndex("dbo.SubjectCourse", new[] { "CourseId" });
            DropIndex("dbo.SubjectCourse", new[] { "SubjectId" });
            DropIndex("dbo.Student", new[] { "CourseId" });
            DropTable("dbo.SubjectCourse");
            DropTable("dbo.Subject");
            DropTable("dbo.Student");
        }
    }
}
