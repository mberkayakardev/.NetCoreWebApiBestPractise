using AkarSoftware.ApiBestPractise.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AkarSoftware.ApiBestPractise.Repository.Seeds
{

    internal class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product() { Id= 1, CreatedDate = DateTime.Now, UpdatedDate= DateTime.Now, Name = "Kalem1", Stock=20, Price = 100, CategoryId = 1   },
                new Product() { Id = 2, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, Name = "Kalem2", Stock = 120, Price = 150, CategoryId = 2 },
                new Product() { Id = 3, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, Name = "Kalem3", Stock = 120, Price = 150, CategoryId = 3 }




                )
        }
    }
}
