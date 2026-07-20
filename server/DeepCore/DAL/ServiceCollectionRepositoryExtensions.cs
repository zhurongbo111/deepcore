using DeepCore.DAL.Repository;
using DeepCore.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DeepCore.DAL
{
    public static class ServiceCollectionRepositoryExtensions
    {
        public static IServiceCollection AddRepository(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DeepCoreDbContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("Default");
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });
            services.AddHostedService<DeepCoreDatabaseMigration>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IPurchaseOrderRepository, PurchaseOrderRepository>();
            services.AddScoped<IPurchaseOrderItemRepository, PurchaseOrderItemRepository>();
            services.AddScoped<ISalesOrderRepository, SalesOrderRepository>();
            services.AddScoped<ISalesOrderItemRepository, SalesOrderItemRepository>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<IInventoryRepository, InventoryRepository>();
            services.AddScoped<IUnitOfWork, EfCoreUnitOfWork>();// Scoped lifetime is important!
            return services;
        }
    }
}
