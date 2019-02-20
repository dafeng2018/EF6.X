using EFFluentAPIRelationships.Entities;
using System.Data.Entity;

namespace EFFluentAPIRelationships
{
    public class EFDbInitializer : CreateDatabaseIfNotExists<EFDbContext>
    {
        protected override void Seed(EFDbContext context)
        {
            context.ProductCatalogs.Add(new ProductCatalog { CatalogName = "DELL E6400", Manufactory = "DELL", ListPrice = 5600, NetPrice = 4300 });
            context.ProductCatalogs.Add(new ProductCatalog { CatalogName = "DELL E6410", Manufactory = "DELL", ListPrice = 6500, NetPrice = 5100 });
            context.ProductCatalogs.Add(new ProductCatalog { CatalogName = "DELL E6420", Manufactory = "DELL", ListPrice = 7000, NetPrice = 5400 });
            base.Seed(context);
        }
    }
}