namespace EFFluentAPIRelationships.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateaddress : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Customers", name: "Address_Country", newName: "Country");
            RenameColumn(table: "dbo.Customers", name: "Address_Province", newName: "Province");
            RenameColumn(table: "dbo.Customers", name: "Address_City", newName: "City");
            RenameColumn(table: "dbo.Customers", name: "Address_StreetAddress", newName: "StreetAddress");
            RenameColumn(table: "dbo.Customers", name: "Address_ZipCode", newName: "ZipCode");
            AlterColumn("dbo.Customers", "Country", c => c.String(maxLength: 100));
            AlterColumn("dbo.Customers", "Province", c => c.String(maxLength: 100));
            AlterColumn("dbo.Customers", "City", c => c.String(maxLength: 100));
            AlterColumn("dbo.Customers", "StreetAddress", c => c.String(maxLength: 500));
            AlterColumn("dbo.Customers", "ZipCode", c => c.String(maxLength: 6));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "ZipCode", c => c.String());
            AlterColumn("dbo.Customers", "StreetAddress", c => c.String());
            AlterColumn("dbo.Customers", "City", c => c.String());
            AlterColumn("dbo.Customers", "Province", c => c.String());
            AlterColumn("dbo.Customers", "Country", c => c.String());
            RenameColumn(table: "dbo.Customers", name: "ZipCode", newName: "Address_ZipCode");
            RenameColumn(table: "dbo.Customers", name: "StreetAddress", newName: "Address_StreetAddress");
            RenameColumn(table: "dbo.Customers", name: "City", newName: "Address_City");
            RenameColumn(table: "dbo.Customers", name: "Province", newName: "Address_Province");
            RenameColumn(table: "dbo.Customers", name: "Country", newName: "Address_Country");
        }
    }
}
