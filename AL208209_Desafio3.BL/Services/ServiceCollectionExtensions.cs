using AL208209_Desafio3.BL.AutoMapper;
using AL208209_Desafio3.BL.Interfaces;
using AL208209_Desafio3.DAL.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AL208209_Desafio3.BL.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServiceConnector(this IServiceCollection services)
        {
            services.AddAutoMapper(_ => { }, typeof(AutoMapperProfile));
            services.AddTransient<IClienteService, ClienteService>();
            services.AddTransient<IProductoService, ProductoService>();
            services.AddTransient<IPedidoService, PedidoService>();
            services.AddRepositoryConnector();
            return services;
        }
    }
}
