namespace MVC_Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtesttablecolumntesten : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tests", "TestEN", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tests", "TestEN");
        }
    }
}
