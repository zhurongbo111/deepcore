using Microsoft.EntityFrameworkCore;
using System.Reflection;
using DeepCore.DAL.Entities;

namespace DeepCore.DAL
{
    /// <summary>
    /// Add-Migration Init -OutputDir DAL/Migrations
    /// docker run -d --name mysql8 -p 3306:3306 -e MYSQL_ROOT_PASSWORD=123456 -e MYSQL_DATABASE=testdb --restart always mysql:8.0 --character-set-server=utf8mb4 --collation-server=utf8mb4_unicode_ci
    /// </summary>
    public class DeepCoreDbContext : DbContext
    {
        public DeepCoreDbContext(DbContextOptions<DeepCoreDbContext> options) : base(options)
        {   
        }

        protected virtual Assembly GetConfigurationAssembly()
        {
            return this.GetType().Assembly;
        }

        protected virtual bool ConfigurationTypeSelector(Type type)
        {
            return type.GetInterfaces()?.Any(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)) ?? false;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetConfigurationAssembly(), ConfigurationTypeSelector);
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<PurchaseOrderItem> PurchaseOrderItems { get; set; }
        public DbSet<SalesOrder> SalesOrders { get; set; }
        public DbSet<SalesOrderItem> SalesOrderItems { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
