using AkarSoftware.ApiBestPractise.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AkarSoftware.ApiBestPractise.Repository.Configuration
{
    internal class ProductFeatureConfiguration : IEntityTypeConfiguration<ProductFeature>
    {
        public void Configure(EntityTypeBuilder<ProductFeature> builder)
        {
            // buradaya da ilgili Konfigü
            builder.HasOne(x => x.Product).WithOne(x => x.Feature).HasForeignKey<ProductFeature>(x => x.ProductId);
        }
    }
}
