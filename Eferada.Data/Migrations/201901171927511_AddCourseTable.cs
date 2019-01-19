namespace Eferada.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCourseTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        DurationInYears = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Course");
        }
    }
}
