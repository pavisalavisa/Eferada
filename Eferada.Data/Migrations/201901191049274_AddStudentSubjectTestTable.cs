namespace Eferada.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStudentSubjectTestTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentSubjectTest",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubjectTestId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                        Participated = c.Boolean(nullable: false),
                        Grade = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Student", t => t.StudentId)
                .ForeignKey("dbo.SubjectTest", t => t.SubjectTestId)
                .Index(t => t.SubjectTestId)
                .Index(t => t.StudentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentSubjectTest", "SubjectTestId", "dbo.SubjectTest");
            DropForeignKey("dbo.StudentSubjectTest", "StudentId", "dbo.Student");
            DropIndex("dbo.StudentSubjectTest", new[] { "StudentId" });
            DropIndex("dbo.StudentSubjectTest", new[] { "SubjectTestId" });
            DropTable("dbo.StudentSubjectTest");
        }
    }
}
