using Guide.Variacao.Seed.Infra.Interfaces;
using Guide.Variacao.Seed.Infra.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Guide.Variacao.Seed.Tests.Api
{
    [Order(1)]
    public class Apitests
    {
        IYahooFinanceService _yahooService;

        [SetUp]
        public void Setup()
        {
            var services = new ServiceCollection();
            services.AddTransient<IYahooFinanceService, YahooFinanceService>();

            var serviceProvider = services.BuildServiceProvider();

            _yahooService = serviceProvider.GetService<IYahooFinanceService>();
        }

        [Test]
        [Order(1)]
        public void ShouldGet404()
        {
            var stockList = _yahooService.RetriveStocks(["IncorrectStockName"]);

            Assert.That(!stockList.Result.Any(), "The Api retrived a incorrect Stock");
        }

        [Test]
        [Order(2)]
        public void ShouldGet200()
        {
            var stockList = _yahooService.RetriveStocks();

            Assert.That(stockList.Result.Any(), "The Api doesn't retrived the default 10 stocks");
        }
    }
}
