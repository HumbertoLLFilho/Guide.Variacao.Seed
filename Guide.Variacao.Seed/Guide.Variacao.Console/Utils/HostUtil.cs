using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Guide.Variacao.Seed.Console.Utils
{
    public static class HostUtil
    {
        public static HostApplicationBuilder Configure(this HostApplicationBuilder builder)
        {
            var configBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            builder.Configuration.AddConfiguration(configBuilder);

            builder.Services.AddServices(builder.Configuration);

            return builder;
        }


    }
}
