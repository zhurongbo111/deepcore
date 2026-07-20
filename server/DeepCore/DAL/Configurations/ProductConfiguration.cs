using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DeepCore.DAL.Entities;

namespace DeepCore.DAL.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Code).IsRequired().HasMaxLength(50);
            builder.HasIndex(x => x.Code).IsUnique();

            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Unit).IsRequired().HasMaxLength(20);

            builder.Property(x => x.PurchasePrice).HasColumnType("decimal(18,2)");
            builder.Property(x => x.SalePrice).HasColumnType("decimal(18,2)");

            builder.Property(x => x.Status).HasDefaultValue(1);

            builder.HasMany(x => x.PurchaseOrderItems)
                .WithOne(i => i.Product)
                .HasForeignKey(i => i.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.SalesOrderItems)
                .WithOne(i => i.Product)
                .HasForeignKey(i => i.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
