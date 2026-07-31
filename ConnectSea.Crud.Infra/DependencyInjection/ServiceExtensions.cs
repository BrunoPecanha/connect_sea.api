using ConnectSea.Crud.Application;
using ConnectSea.Crud.Domain.Repository;
using ConnectSea.Crud.Domain.Service;
using ConnectSea.Crud.Infra.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace ConnectSea.Crud.Infra.DependencyInjection
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IEscalaService, EscalaService>();
            services.AddScoped<IEscalaRepository, EscalaRepository>();

            services.AddScoped<IManifestoService, ManifestoService>();
            services.AddScoped<IManifestoRepository, ManifestoRespository>();

            services.AddScoped<IManifestoEscalaRepository, ManifestoEscalaRespository>();

            return services;
        }
    }
}
