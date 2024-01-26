using Guide.Variacao.Core.DataBase.Configurations;
using Guide.Variacao.Core.DataBase.Repository;
using Microsoft.Extensions.DependencyInjection;
using Guide.Variacao.Seed.Domain.Interfaces;
using Guide.Variacao.Seed.Infra.Interfaces;
using Guide.Variacao.Seed.Domain.Services;
using Guide.Variacao.Seed.Infra.Services;
using Microsoft.Extensions.Configuration;
using Guide.Variacao.Seed.Infra.Context;

namespace Guide.Variacao.Seed.Console.Utils
{
    public static class ServiceUtil
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Database Configuration
            services.ConfigureDbContext<GuideVariacaoContext>(configuration);

            //Class services
            services.AddSingleton<IYahooFinanceService, YahooFinanceService>();
            services.AddSingleton<IStockService, StockService>();

            //Repositories
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

            return services;
        }

        public static T GetMyService<T>(this IServiceProvider services) where T : class =>
            services.GetService<T>() ?? throw new ArgumentNullException(typeof(T).Name.ToString());

    }
}
