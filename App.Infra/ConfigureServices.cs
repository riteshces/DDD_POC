using App.Domain.Repository;
using App.Infra.Data;
using App.Infra.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace App.Infra
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfraServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<AppDBContext>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IInvoiceRepository, InvoiceRepository>();
            return services;
        }
    }
}
