namespace Eferada.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNoticeTableAndEmployeeTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Address = c.String(nullable: false, maxLength: 64, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Notice",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 64, unicode: false),
                        Content = c.String(nullable: false, maxLength: 512, unicode: false),
                        PublicationDateTime = c.DateTime(nullable: false),
                        NoticeCreatorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employee", t => t.NoticeCreatorId, cascadeDelete: true)
                .Index(t => t.NoticeCreatorId);
            
            CreateIndex("dbo.Users", "Id");
            AddForeignKey("dbo.Users", "Id", "dbo.Employee", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notice", "NoticeCreatorId", "dbo.Employee");
            DropForeignKey("dbo.Users", "Id", "dbo.Employee");
            DropIndex("dbo.Notice", new[] { "NoticeCreatorId" });
            DropIndex("dbo.Users", new[] { "Id" });
            DropTable("dbo.Notice");
            DropTable("dbo.Employee");
        }
    }
}
