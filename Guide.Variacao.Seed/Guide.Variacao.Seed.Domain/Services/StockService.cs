using Guide.Variacao.Core.DataBase.Repository;
using Guide.Variacao.Seed.Domain.Interfaces;
using Guide.Variacao.Seed.Infra.Interfaces;
using Guide.Variacao.Core.Domain.Models;
using Guide.Variacao.Seed.Domain.Utils;

namespace Guide.Variacao.Seed.Domain.Services
{
    public class StockService : IStockService
    {
        private readonly IYahooFinanceService _yahooFinance;
        private readonly IRepository<Stock> _repository;

        public StockService(IYahooFinanceService yahooFinance, IRepository<Stock> repository)
        {
            _yahooFinance = yahooFinance;
            _repository = repository;
        }

        public async Task<List<Stock>> GetFromAPI(List<string>? stocks = null)
        {
            var charts = await _yahooFinance.RetriveStocks(stocks);

            return charts.ToStocks();
        }

        public List<Stock> Get() => _repository.Get().ToList();
        public Stock? GetById(Guid id) => _repository.GetById(id);
        public void Add(List<Stock> stocks) => _repository.Add(stocks.AsQueryable());
    }
}
