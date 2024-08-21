using Marten.Schema;

namespace Catalog.API.Data
{
    public class CatalogInitialData : IInitialData
    {
        public async Task Populate(IDocumentStore store, CancellationToken cancellation)
        {
            using var session = store.LightweightSession();

            if (await session.Query<Product>().AnyAsync(cancellation))
            {
                return;
            }

            session.Store(GetConfiguredProducts());
            await session.SaveChangesAsync(cancellation);
        }

        private static IEnumerable<Product> GetConfiguredProducts() => new List<Product>
        {
            new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Iphone X",
                Description = "This phone is the company's biggest change to its followers.",
                ImageFile = "product-1.png",
                Price = 950.00M,
                Category = new List<string> { "Smartphone" }
            },
            new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Samsung S23 Ultra",
                Description = "This phone is the company's biggest change to its followers.",
                ImageFile = "product-2.png",
                Price = 1050.00M,
                Category = new List<string> { "Smartphone" }
            },
            new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Samsung S24",
                Description = "This phone is the company's biggest change to its followers.",
                ImageFile = "product-3.png",
                Price = 1000.00M,
                Category = new List<string> { "Smartphone" }
            },
            new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Macbook Pro",
                Description = "This laptop is the company's biggest change to its followers.",
                ImageFile = "product-4.png",
                Price = 4500.00M,
                Category = new List<string> { "Laptops" }
            },
            new Product()
            {
                Id = Guid.NewGuid(),
                Name = "HP Pro 10",
                Description = "This laptop is the company's biggest change to its followers.",
                ImageFile = "product-5.png",
                Price = 5500.00M,
                Category = new List<string> { "Laptops" }
            }
        };
    }
}
