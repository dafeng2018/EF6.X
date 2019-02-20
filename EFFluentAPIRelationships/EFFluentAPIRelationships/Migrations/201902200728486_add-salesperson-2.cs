namespace EFFluentAPIRelationships.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addsalesperson2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        OrderItemId = c.Int(nullable: false, identity: true),
                        RetailPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderItemId)
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .Index(t => t.OrderID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        CreatedDate = c.DateTime(nullable: false),
                        ApprovedBy = c.String(maxLength: 128),
                        CreatedBy = c.String(maxLength: 128),
                        Customer_IDCardNumber = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.SalesPersons", t => t.ApprovedBy)
                .ForeignKey("dbo.SalesPersons", t => t.CreatedBy)
                .ForeignKey("dbo.Customers", t => t.Customer_IDCardNumber)
                .Index(t => t.ApprovedBy)
                .Index(t => t.CreatedBy)
                .Index(t => t.Customer_IDCardNumber);
            
            CreateTable(
                "dbo.SalesPersons",
                c => new
                    {
                        EmployeeID = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 100),
                        Gender = c.String(nullable: false, maxLength: 1),
                        HiredDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderItems", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.Orders", "Customer_IDCardNumber", "dbo.Customers");
            DropForeignKey("dbo.Orders", "CreatedBy", "dbo.SalesPersons");
            DropForeignKey("dbo.Orders", "ApprovedBy", "dbo.SalesPersons");
            DropIndex("dbo.Orders", new[] { "Customer_IDCardNumber" });
            DropIndex("dbo.Orders", new[] { "CreatedBy" });
            DropIndex("dbo.Orders", new[] { "ApprovedBy" });
            DropIndex("dbo.OrderItems", new[] { "OrderID" });
            DropTable("dbo.SalesPersons");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderItems");
        }
    }
}
