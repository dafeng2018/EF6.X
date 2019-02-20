namespace EFFluentAPIRelationships.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addSalesPromotionBankAccount : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BankAccounts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CreatedDate = c.DateTime(nullable: false),
                        BankName = c.String(),
                        AccountName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SalesPromotions",
                c => new
                    {
                        SalesPromotionId = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        SalesDiscount = c.Decimal(nullable: false, precision: 18, scale: 4),
                    })
                .PrimaryKey(t => t.SalesPromotionId);
            
            CreateTable(
                "dbo.ProductCatalogSalesPromotion",
                c => new
                    {
                        PromotionId = c.Int(nullable: false),
                        CatalogId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PromotionId, t.CatalogId })
                .ForeignKey("dbo.SalesPromotions", t => t.PromotionId, cascadeDelete: true)
                .ForeignKey("dbo.ProductCatalogs", t => t.CatalogId, cascadeDelete: true)
                .Index(t => t.PromotionId)
                .Index(t => t.CatalogId);
            
            AddColumn("dbo.Customers", "Account_ID", c => c.Int());
            CreateIndex("dbo.Customers", "Account_ID");
            AddForeignKey("dbo.Customers", "Account_ID", "dbo.BankAccounts", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductCatalogSalesPromotion", "CatalogId", "dbo.ProductCatalogs");
            DropForeignKey("dbo.ProductCatalogSalesPromotion", "PromotionId", "dbo.SalesPromotions");
            DropForeignKey("dbo.Customers", "Account_ID", "dbo.BankAccounts");
            DropIndex("dbo.ProductCatalogSalesPromotion", new[] { "CatalogId" });
            DropIndex("dbo.ProductCatalogSalesPromotion", new[] { "PromotionId" });
            DropIndex("dbo.Customers", new[] { "Account_ID" });
            DropColumn("dbo.Customers", "Account_ID");
            DropTable("dbo.ProductCatalogSalesPromotion");
            DropTable("dbo.SalesPromotions");
            DropTable("dbo.BankAccounts");
        }
    }
}
