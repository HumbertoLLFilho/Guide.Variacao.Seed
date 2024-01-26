using Guide.Variacao.Seed.Core.Models;

namespace Guide.Variacao.Seed.Infra.Interfaces
{
    public interface IYahooFinanceService
    {
        Task<List<Chart>> RetriveStocks(List<string>? stocks = null);
    }
}
