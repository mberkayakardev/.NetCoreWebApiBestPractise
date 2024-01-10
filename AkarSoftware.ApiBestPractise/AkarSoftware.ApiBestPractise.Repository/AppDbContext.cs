using AkarSoftware.ApiBestPractise.Core.Entities;
using AkarSoftware.ApiBestPractise.Repository.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AkarSoftware.ApiBestPractise.Repository
{
    public class AppDbContext : DbContext // Farklı assembly den erişilebilsin diyes
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {
            // Bu options u alma sebebi İlgili DbContext Konfigürasyonlarını Business ( startup ) içerisinden verebilmek için. 
            // startup üzerinden konfigüre edebileceğim. 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            base.OnModelCreating(modelBuilder); 
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is BaseEntity EntityReference)
                {
                    EntityReference.UpdatedDate = DateTime.Now;
                    switch (item.State)
                    {
                        case EntityState.Added:
                            EntityReference.CreatedDate = DateTime.Now;
                            break;
                    }
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        // Her bir entity e karşılık bir DbSet Oluşturulacaktır. 
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; } 
        
        // Product ile ilgilidir. Product feature buraya eklersem
        // bağımsız bir şekilde db ye productfeature ü
        // bağımsız bir şekilde ekleyebilirim. bunu burdan kapatırsam
        // mutlaka product üzerinden eklesin diyebilirim. 
    }
}

