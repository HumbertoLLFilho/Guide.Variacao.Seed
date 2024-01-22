using Guide.Variacao.Core.Domain.Models;

namespace Guide.Variacao.Seed.Domain.Interfaces
{
    public interface IStockService
    {
        Task<List<Stock>> GetFromAPI(List<string>? stocks = null);

        List<Stock> Get();
        Stock? GetById(Guid id);
        void Add(List<Stock> stocks);
    }
}
