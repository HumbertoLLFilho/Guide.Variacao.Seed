using Microsoft.Extensions.DependencyInjection;
using Guide.Variacao.Seed.Domain.Interfaces;
using Guide.Variacao.Core.DataBase.Utils;
using Guide.Variacao.Seed.Infra.Context;
using Guide.Variacao.Seed.Console.Utils;
using Microsoft.Extensions.Hosting;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = Host.CreateApplicationBuilder(args)
            .Configure();

        var host = builder.Build();
        var serviceProvide = host.Services;

        //Ensure that the Database is properly created
        serviceProvide.Reset<GuideVariacaoContext>();

        var StockService = serviceProvide.GetMyService<IStockService>();

        var stocks = StockService.GetFromAPI().Result;

        StockService.Add(stocks);
    }
}