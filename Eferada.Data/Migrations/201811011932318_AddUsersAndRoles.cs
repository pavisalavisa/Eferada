namespace Eferada.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddUsersAndRoles : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            RenameTable(name: "dbo.AspNetRoles", newName: "Roles");
            RenameTable(name: "dbo.AspNetUsers", newName: "Users");
            RenameTable(name: "dbo.AspNetUserClaims", newName: "UserClaims");
            RenameTable(name: "dbo.AspNetUserLogins", newName: "ApplicationUserLogin");
            RenameTable(name: "dbo.AspNetUserRoles", newName: "UserRoles");
            DropIndex("dbo.Roles", "RoleNameIndex");
            DropIndex("dbo.UserRoles", new[] { "UserId" });
            DropIndex("dbo.UserRoles", new[] { "RoleId" });
            DropIndex("dbo.Users", "UserNameIndex");
            DropIndex("dbo.UserClaims", new[] { "UserId" });
            DropIndex("dbo.ApplicationUserLogin", new[] { "UserId" });
            DropPrimaryKey("dbo.Roles");
            DropPrimaryKey("dbo.Users");
            DropPrimaryKey("dbo.ApplicationUserLogin");
            DropPrimaryKey("dbo.UserRoles");
            AddColumn("dbo.Users", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Users", "LastName", c => c.String(maxLength: 50));
            AddColumn("dbo.Users", "Title", c => c.String(maxLength: 25));
            AddColumn("dbo.Users", "CreatedTimestamp", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "LastUpdatedTimestamp", c => c.DateTime());
            AddColumn("dbo.Users", "Pending", c => c.Boolean(nullable: false));
            AddColumn("dbo.ApplicationUserLogin", "LoginProvidet", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.UserRoles", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Roles", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Roles", "Name", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.Users", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Users", "Email", c => c.String(maxLength: 100));
            AlterColumn("dbo.Users", "PasswordHash", c => c.String(maxLength: 100));
            AlterColumn("dbo.Users", "SecurityStamp", c => c.String(maxLength: 100));
            AlterColumn("dbo.Users", "PhoneNumber", c => c.String(maxLength: 25));
            AlterColumn("dbo.Users", "UserName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.UserClaims", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.ApplicationUserLogin", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.UserRoles", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.UserRoles", "RoleId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Roles", "Id");
            AddPrimaryKey("dbo.Users", "Id");
            AddPrimaryKey("dbo.ApplicationUserLogin", new[] { "UserId", "LoginProvidet", "ProviderKey" });
            AddPrimaryKey("dbo.UserRoles", new[] { "Id", "UserId", "RoleId" });
            CreateIndex("dbo.UserRoles", "UserId");
            CreateIndex("dbo.UserRoles", "RoleId");
            CreateIndex("dbo.UserClaims", "UserId");
            CreateIndex("dbo.ApplicationUserLogin", "UserId");
            AddForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserClaims", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ApplicationUserLogin", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserRoles", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            DropColumn("dbo.ApplicationUserLogin", "LoginProvider");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ApplicationUserLogin", "LoginProvider", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.UserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.ApplicationUserLogin", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserClaims", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles");
            DropIndex("dbo.ApplicationUserLogin", new[] { "UserId" });
            DropIndex("dbo.UserClaims", new[] { "UserId" });
            DropIndex("dbo.UserRoles", new[] { "RoleId" });
            DropIndex("dbo.UserRoles", new[] { "UserId" });
            DropPrimaryKey("dbo.UserRoles");
            DropPrimaryKey("dbo.ApplicationUserLogin");
            DropPrimaryKey("dbo.Users");
            DropPrimaryKey("dbo.Roles");
            AlterColumn("dbo.UserRoles", "RoleId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.UserRoles", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.ApplicationUserLogin", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.UserClaims", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Users", "UserName", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.Users", "PhoneNumber", c => c.String());
            AlterColumn("dbo.Users", "SecurityStamp", c => c.String());
            AlterColumn("dbo.Users", "PasswordHash", c => c.String());
            AlterColumn("dbo.Users", "Email", c => c.String(maxLength: 256));
            AlterColumn("dbo.Users", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Roles", "Name", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.Roles", "Id", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.UserRoles", "Id");
            DropColumn("dbo.ApplicationUserLogin", "LoginProvidet");
            DropColumn("dbo.Users", "Pending");
            DropColumn("dbo.Users", "LastUpdatedTimestamp");
            DropColumn("dbo.Users", "CreatedTimestamp");
            DropColumn("dbo.Users", "Title");
            DropColumn("dbo.Users", "LastName");
            DropColumn("dbo.Users", "FirstName");
            AddPrimaryKey("dbo.UserRoles", new[] { "UserId", "RoleId" });
            AddPrimaryKey("dbo.ApplicationUserLogin", new[] { "LoginProvider", "ProviderKey", "UserId" });
            AddPrimaryKey("dbo.Users", "Id");
            AddPrimaryKey("dbo.Roles", "Id");
            CreateIndex("dbo.ApplicationUserLogin", "UserId");
            CreateIndex("dbo.UserClaims", "UserId");
            CreateIndex("dbo.Users", "UserName", unique: true, name: "UserNameIndex");
            CreateIndex("dbo.UserRoles", "RoleId");
            CreateIndex("dbo.UserRoles", "UserId");
            CreateIndex("dbo.Roles", "Name", unique: true, name: "RoleNameIndex");
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.UserRoles", newName: "AspNetUserRoles");
            RenameTable(name: "dbo.ApplicationUserLogin", newName: "AspNetUserLogins");
            RenameTable(name: "dbo.UserClaims", newName: "AspNetUserClaims");
            RenameTable(name: "dbo.Users", newName: "AspNetUsers");
            RenameTable(name: "dbo.Roles", newName: "AspNetRoles");
        }
    }
}
