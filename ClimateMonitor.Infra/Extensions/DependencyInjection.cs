using ClimateMonitor.Domain.Repositories;
using ClimateMonitor.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;
namespace ClimateMonitor.Infra.Extensions;

public static class DependencyInjection
    {
        
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IClimateSampleRepository, ClimateSampleRepository>();
        }
        public static void AddMediatRApi(this IServiceCollection services)
        {
           // services.AddMediatR(typeof(AdcionarMarcaCommand));
           // services.AddMediatR(typeof(AdcionarProdutoCommand));

            //services.AddMediatR(typeof(ObterMarcaPorIdQuery));
            //services.AddMediatR(typeof(ObterTodasAsMarcasQuery));
        }
        // public static IServiceCollection AddAutoMapperApi(this IServiceCollection services, Type assemblyContainingMappers)
        // {
        //     services.AddAutoMapper(expression =>
        //     {
        //         expression.AllowNullCollections = true;
        //     }, assemblyContainingMappers);

        //     return services;
        // }
    }