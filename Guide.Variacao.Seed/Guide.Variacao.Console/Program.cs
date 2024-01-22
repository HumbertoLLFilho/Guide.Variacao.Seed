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
        Console.WriteLine("Creating services");
        var builder = Host.CreateApplicationBuilder(args)
            .Configure();

        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        var host = builder.Build();
        var serviceProvide = host.Services;

        Console.WriteLine("Ensuring that the database is created");
        //Ensure that the Database is properly created
        serviceProvide.Reset<GuideVariacaoContext>();

        var StockService = serviceProvide.GetMyService<IStockService>();

        Console.WriteLine("Retrieving data from the Yahoo Finance API");
        var stocks = StockService.GetFromAPI().Result;

        Console.WriteLine("Addind data to the database...");
        StockService.Add(stocks);

        Console.WriteLine("Done configuring!");
    }
}