using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DeepCore.DAL.Entities;

namespace DeepCore.DAL.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Table name includes brackets in attribute; keep same to preserve behavior
            builder.ToTable("Users");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.PublicUserId).IsRequired();
            builder.HasIndex(x => x.PublicUserId).IsUnique();

            builder.Property(x => x.UserName).IsRequired().HasMaxLength(50);
            builder.HasIndex(x => x.UserName).IsUnique();

            builder.Property(x => x.Status).HasDefaultValue(1); // Default status is 1 (active)
            builder.Property(x => x.PasswordHash).IsRequired().HasMaxLength(200);
            builder.Property(x => x.RealName).HasMaxLength(50);
            builder.Property(x => x.Phone).HasMaxLength(20);
            builder.Property(x => x.Email).HasMaxLength(100);

            DateTimeOffset now = new DateTimeOffset(2026, 7, 16, 0, 0, 0, TimeSpan.FromHours(8));
            Guid adminId = Guid.Parse("A4492F91-EE15-4CB4-83BC-8A48CA0B43B0");
            builder.HasData(
                new User
                {
                    Id = 1,
                    PublicUserId = adminId,
                    UserName = "admin",
                    PasswordHash = "AQAAAAIAAYagAAAAEC8D8rWWMxZn5POiC5IQI1KKLTOYPeqLrip27T2uUQBpGHsZ6JJS5R/6UECsn0wRvQ==", // 123456
                    RealName = "Administrator",
                    Phone = "1234567890",
                    Email = "admin@exmaple.com",
                    CreatedTime = now,
                    UpdatedTime = now,
                    Status = 1,

                }
            );
        }
    }
}
