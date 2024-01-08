using AkarSoftware.ApiBestPractise.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AkarSoftware.ApiBestPractise.Repository.Seeds
{
    internal class CategorySeed : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new() { Id = 1, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, CategoryName = "Kalemler" },
                new() { Id = 2, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, CategoryName = "Kitaplar" },
                new() { Id = 3, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, CategoryName = "Defterler" }
                );
        }
    }
}
