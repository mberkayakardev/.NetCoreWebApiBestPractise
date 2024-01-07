using AkarSoftware.ApiBestPractise.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AkarSoftware.ApiBestPractise.Repository.Configuration
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=> x.Id).UseIdentityColumn(); // değer vermezsen 1 er 1 er artar

            builder.Property(x=>x.CategoryName).IsRequired();
            builder.Property(x => x.CategoryName).HasMaxLength(100);

            builder.ToTable("Kategori");





        }
    }
}
