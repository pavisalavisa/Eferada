namespace Eferada.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeIdsAsIdentity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Student", "CourseId", "dbo.Course");
            DropForeignKey("dbo.SubjectTest", "CourseId", "dbo.Course");
            DropForeignKey("dbo.SubjectCourse", "CourseId", "dbo.Course");
            DropForeignKey("dbo.Users", "Id", "dbo.Student");
            DropForeignKey("dbo.StudentSubjectTest", "StudentId", "dbo.Student");
            DropForeignKey("dbo.SubjectStudent", "StudentId", "dbo.Student");
            DropForeignKey("dbo.StudentSubjectTest", "SubjectTestId", "dbo.SubjectTest");
            DropForeignKey("dbo.SubjectCourse", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.SubjectStudent", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.SubjectTest", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.Users", "Id", "dbo.Employee");
            DropForeignKey("dbo.Notice", "NoticeCreatorId", "dbo.Employee");
            DropPrimaryKey("dbo.Course");
            DropPrimaryKey("dbo.Student");
            DropPrimaryKey("dbo.SubjectTest");
            DropPrimaryKey("dbo.Subject");
            DropPrimaryKey("dbo.Employee");
            DropPrimaryKey("dbo.Notice");
            AlterColumn("dbo.Course", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Student", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.SubjectTest", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Subject", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Employee", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Notice", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Course", "Id");
            AddPrimaryKey("dbo.Student", "Id");
            AddPrimaryKey("dbo.SubjectTest", "Id");
            AddPrimaryKey("dbo.Subject", "Id");
            AddPrimaryKey("dbo.Employee", "Id");
            AddPrimaryKey("dbo.Notice", "Id");
            AddForeignKey("dbo.Student", "CourseId", "dbo.Course", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SubjectTest", "CourseId", "dbo.Course", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SubjectCourse", "CourseId", "dbo.Course", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Users", "Id", "dbo.Student", "Id");
            AddForeignKey("dbo.StudentSubjectTest", "StudentId", "dbo.Student", "Id");
            AddForeignKey("dbo.SubjectStudent", "StudentId", "dbo.Student", "Id", cascadeDelete: true);
            AddForeignKey("dbo.StudentSubjectTest", "SubjectTestId", "dbo.SubjectTest", "Id");
            AddForeignKey("dbo.SubjectCourse", "SubjectId", "dbo.Subject", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SubjectStudent", "SubjectId", "dbo.Subject", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SubjectTest", "SubjectId", "dbo.Subject", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Users", "Id", "dbo.Employee", "Id");
            AddForeignKey("dbo.Notice", "NoticeCreatorId", "dbo.Employee", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notice", "NoticeCreatorId", "dbo.Employee");
            DropForeignKey("dbo.Users", "Id", "dbo.Employee");
            DropForeignKey("dbo.SubjectTest", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.SubjectStudent", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.SubjectCourse", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.StudentSubjectTest", "SubjectTestId", "dbo.SubjectTest");
            DropForeignKey("dbo.SubjectStudent", "StudentId", "dbo.Student");
            DropForeignKey("dbo.StudentSubjectTest", "StudentId", "dbo.Student");
            DropForeignKey("dbo.Users", "Id", "dbo.Student");
            DropForeignKey("dbo.SubjectCourse", "CourseId", "dbo.Course");
            DropForeignKey("dbo.SubjectTest", "CourseId", "dbo.Course");
            DropForeignKey("dbo.Student", "CourseId", "dbo.Course");
            DropPrimaryKey("dbo.Notice");
            DropPrimaryKey("dbo.Employee");
            DropPrimaryKey("dbo.Subject");
            DropPrimaryKey("dbo.SubjectTest");
            DropPrimaryKey("dbo.Student");
            DropPrimaryKey("dbo.Course");
            AlterColumn("dbo.Notice", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Employee", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Subject", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.SubjectTest", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Student", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Course", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Notice", "Id");
            AddPrimaryKey("dbo.Employee", "Id");
            AddPrimaryKey("dbo.Subject", "Id");
            AddPrimaryKey("dbo.SubjectTest", "Id");
            AddPrimaryKey("dbo.Student", "Id");
            AddPrimaryKey("dbo.Course", "Id");
            AddForeignKey("dbo.Notice", "NoticeCreatorId", "dbo.Employee", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Users", "Id", "dbo.Employee", "Id");
            AddForeignKey("dbo.SubjectTest", "SubjectId", "dbo.Subject", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SubjectStudent", "SubjectId", "dbo.Subject", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SubjectCourse", "SubjectId", "dbo.Subject", "Id", cascadeDelete: true);
            AddForeignKey("dbo.StudentSubjectTest", "SubjectTestId", "dbo.SubjectTest", "Id");
            AddForeignKey("dbo.SubjectStudent", "StudentId", "dbo.Student", "Id", cascadeDelete: true);
            AddForeignKey("dbo.StudentSubjectTest", "StudentId", "dbo.Student", "Id");
            AddForeignKey("dbo.Users", "Id", "dbo.Student", "Id");
            AddForeignKey("dbo.SubjectCourse", "CourseId", "dbo.Course", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SubjectTest", "CourseId", "dbo.Course", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Student", "CourseId", "dbo.Course", "Id", cascadeDelete: true);
        }
    }
}
