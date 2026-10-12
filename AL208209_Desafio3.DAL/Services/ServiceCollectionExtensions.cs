using AL208209_Desafio3.DAL.Interfaces;
using AL208209_Desafio3.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;
namespace AL208209_Desafio3.DAL.Services
{ 
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositoryConnector(this IServiceCollection services)
        {
            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<IProductoRepository, ProductoRepository>();
            services.AddTransient<IPedidoRepository, PedidoRepository   >();
            return services;
        }
    }
}
