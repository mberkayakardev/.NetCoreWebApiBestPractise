using EfPractise.WEBUI.Datas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EfPractise.WEBUI.Datas.Contexts
{
    public class UdemyContext : DbContext
    {
        public UdemyContext(DbContextOptions<UdemyContext> options) : base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products>().HasData(new Products { Id = 1, Name = "Berkay", Quantity = 20  });
        }


        public DbSet<Products> Products { get; set; }
    }
}
