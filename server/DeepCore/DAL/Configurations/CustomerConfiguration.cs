using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DeepCore.DAL.Entities;

namespace DeepCore.DAL.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.ContactName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Phone).IsRequired().HasMaxLength(20);
            builder.Property(x => x.Address).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Remark).HasMaxLength(500);

            builder.Property(x => x.Status).HasDefaultValue(1);

            builder.HasMany(x => x.SalesOrders)
                .WithOne(s => s.Customer)
                .HasForeignKey(s => s.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
