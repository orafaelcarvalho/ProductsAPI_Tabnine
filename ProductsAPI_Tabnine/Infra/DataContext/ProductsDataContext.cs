using Microsoft.EntityFrameworkCore;
using ProductsAPI_Tabnine.Domain.Entities;
using ProductsAPI_Tabnine.Domain.Enums;

namespace ProductsAPI_Tabnine.Infra.DataContext
{
    public class ProductsDataContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ProductsDataContext(DbContextOptions<ProductsDataContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Description)
                      .IsRequired()
                      .HasMaxLength(255);

                entity.Property(e => e.Status)
                      .HasConversion(
                          v => v.ToString(),
                          v => (ProductStatus)Enum.Parse(typeof(ProductStatus), v))
                      .IsRequired();

                entity.Property(e => e.ManufacturingDate)
                      .IsRequired();

                entity.Property(e => e.ExpirationDate)
                      .IsRequired();

                entity.Property(e => e.SupplierCode)
                      .IsRequired()
                      .HasMaxLength(100);
            });
        }
    }
}