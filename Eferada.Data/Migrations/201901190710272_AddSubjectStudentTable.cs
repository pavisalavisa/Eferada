namespace Eferada.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddSubjectStudentTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SubjectStudent",
                c => new
                {
                    SubjectId = c.Int(nullable: false),
                    StudentId = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.SubjectId, t.StudentId })
                .ForeignKey("dbo.Subject", t => t.SubjectId, cascadeDelete: true)
                .ForeignKey("dbo.Student", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.SubjectId)
                .Index(t => t.StudentId);

        }

        public override void Down()
        {
            DropForeignKey("dbo.SubjectStudent", "StudentId", "dbo.Student");
            DropForeignKey("dbo.SubjectStudent", "SubjectId", "dbo.Subject");
            DropIndex("dbo.SubjectStudent", new[] { "StudentId" });
            DropIndex("dbo.SubjectStudent", new[] { "SubjectId" });
            DropTable("dbo.SubjectStudent");
        }
    }
}
