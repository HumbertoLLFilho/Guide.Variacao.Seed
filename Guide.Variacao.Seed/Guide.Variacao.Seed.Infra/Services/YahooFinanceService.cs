using Guide.Variacao.Seed.Core.Models;
using Guide.Variacao.Seed.Infra.Interfaces;
using Guide.Variacao.Seed.Infra.Utils;
using System;

namespace Guide.Variacao.Seed.Infra.Services
{
    public class YahooFinanceService : IYahooFinanceService
    {
        public async Task<List<Chart>> RetriveStocks(List<string>? stocks)
        {
            List<Chart> retrivedCharts = [];

            stocks ??= Stocks.Get();


            var client = new HttpClient();
            foreach (var stock in stocks)
            {
                var baseUri = new Uri($"https://query2.finance.yahoo.com/v8/finance/chart/{stock}?range=2y&interval=1d");

                var response = await client.GetAsync(baseUri);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    var chart = JsonUtil.Deserialize<Chart>(content, ignoreRoot: true);

                    retrivedCharts.Add(chart);
                }
            }

            return retrivedCharts;
        }
    }
}
