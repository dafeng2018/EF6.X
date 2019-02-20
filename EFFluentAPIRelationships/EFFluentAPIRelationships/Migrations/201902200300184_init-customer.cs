namespace EFFluentAPIRelationships.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initcustomer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        IDCardNumber = c.String(nullable: false, maxLength: 20),
                        CustomerName = c.String(nullable: false, maxLength: 50),
                        Gender = c.String(nullable: false, maxLength: 1),
                        Address = c.String(),
                        PhoneNumber = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.IDCardNumber);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Customers");
        }
    }
}
