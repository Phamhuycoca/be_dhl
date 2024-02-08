using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Context
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext(DbContextOptions options) : base(options)
        {

        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(e =>
            {
                e.ToTable("Category");
                e.HasKey(e => e.CategoryId);
                e.Property(e => e.CategoryId).IsRequired();
                e.Property(e => e.CategoryName).IsRequired().HasMaxLength(100);
            });
            modelBuilder.Entity<Product>(e =>
            {
                e.ToTable("Product");
                e.HasKey(e => e.ProductId);
                e.Property(e => e.ProductId).IsRequired();
                e.Property(e => e.ProductName).IsRequired().HasMaxLength(100);

                e.HasOne(x=>x.Category).WithMany(p=>p.Products).HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.ClientSetNull);
            });
            base.OnModelCreating(modelBuilder);
        }

    }
}
