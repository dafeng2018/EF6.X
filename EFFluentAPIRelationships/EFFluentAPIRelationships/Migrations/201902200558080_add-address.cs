namespace EFFluentAPIRelationships.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addaddress : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Address_Country", c => c.String());
            AddColumn("dbo.Customers", "Address_Province", c => c.String());
            AddColumn("dbo.Customers", "Address_City", c => c.String());
            AddColumn("dbo.Customers", "Address_StreetAddress", c => c.String());
            AddColumn("dbo.Customers", "Address_ZipCode", c => c.String());
            DropColumn("dbo.Customers", "Address");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Address", c => c.String());
            DropColumn("dbo.Customers", "Address_ZipCode");
            DropColumn("dbo.Customers", "Address_StreetAddress");
            DropColumn("dbo.Customers", "Address_City");
            DropColumn("dbo.Customers", "Address_Province");
            DropColumn("dbo.Customers", "Address_Country");
        }
    }
}
