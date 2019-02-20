namespace EFFluentAPIRelationships.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initproduct : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductCatalogs",
                c => new
                    {
                        ProductCatalogId = c.Int(nullable: false, identity: true),
                        CatalogName = c.String(),
                        Manufactory = c.String(),
                        ListPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NetPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ProductCatalogId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ProductCatalogs");
        }
    }
}
