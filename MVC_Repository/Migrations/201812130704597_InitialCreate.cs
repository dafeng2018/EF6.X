namespace MVC_Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SysRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CName = c.String(),
                        Description = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SysUserRoles",
                c => new
                    {
                        SysUserID = c.Int(nullable: false),
                        SysRoleID = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.SysUserID, t.SysRoleID })
                .ForeignKey("dbo.SysRoles", t => t.SysRoleID, cascadeDelete: true)
                .ForeignKey("dbo.SysUserInfoes", t => t.SysUserID, cascadeDelete: true)
                .Index(t => t.SysUserID)
                .Index(t => t.SysRoleID);
            
            CreateTable(
                "dbo.SysUserInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Password = c.String(),
                        Email = c.String(),
                        CName = c.String(),
                        Description = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SysUserRoles", "SysUserID", "dbo.SysUserInfoes");
            DropForeignKey("dbo.SysUserRoles", "SysRoleID", "dbo.SysRoles");
            DropIndex("dbo.SysUserRoles", new[] { "SysRoleID" });
            DropIndex("dbo.SysUserRoles", new[] { "SysUserID" });
            DropTable("dbo.SysUserInfoes");
            DropTable("dbo.SysUserRoles");
            DropTable("dbo.SysRoles");
        }
    }
}
