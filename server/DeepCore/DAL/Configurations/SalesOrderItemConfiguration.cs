using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DeepCore.DAL.Entities;

namespace DeepCore.DAL.Configurations
{
    public class SalesOrderItemConfiguration : IEntityTypeConfiguration<SalesOrderItem>
    {
        public void Configure(EntityTypeBuilder<SalesOrderItem> builder)
        {
            builder.ToTable("SalesOrderItem");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Quantity).HasColumnType("decimal(18,2)");
            builder.Property(x => x.Price).HasColumnType("decimal(18,2)");
            builder.Property(x => x.Amount).HasColumnType("decimal(18,2)");

            builder.HasOne(x => x.Order)
                .WithMany(o => o.Items)
                .HasForeignKey(x => x.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Product)
                .WithMany(p => p.SalesOrderItems)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
