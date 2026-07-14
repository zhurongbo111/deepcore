using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DeepCore.DAL.Entities;

namespace DeepCore.DAL.Configurations
{
    public class InventoryConfiguration : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.ToTable("Inventory");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Quantity).HasColumnType("decimal(18,2)");
            builder.Property(x => x.LockedQuantity).HasColumnType("decimal(18,2)");
            builder.Property(x => x.AvailableQuantity).HasColumnType("decimal(18,2)");

            builder.Property(x => x.CreatedTime).IsRequired();
            builder.Property(x => x.UpdatedTime).IsRequired();

            builder.HasOne(x => x.Product)
                .WithMany()
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
