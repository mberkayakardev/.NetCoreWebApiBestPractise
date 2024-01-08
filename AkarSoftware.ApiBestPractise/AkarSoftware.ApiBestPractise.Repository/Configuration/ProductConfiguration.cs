using AkarSoftware.ApiBestPractise.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AkarSoftware.ApiBestPractise.Repository.Configuration
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn(); // id değeri 1 er 1 er artar
            
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(350);
            builder.Property(x => x.Stock).IsRequired();
            builder.Property(x => x.Price).HasPrecision(12, 2);

            builder.ToTable("Urunler");

            // 18,3 şeklinde olan ondalıklı ibareyi bu şekilde konfigüre ettim

            /// Entity Framework için tek taraflı bir şekilde (iki entity arasındaki ilişkiyi) belirtmeniz yeterli. 

            builder.HasOne(x=> x.Category).WithMany(x=> x.Products).HasForeignKey(x=>x.CategoryId); 

        }

    }
}
