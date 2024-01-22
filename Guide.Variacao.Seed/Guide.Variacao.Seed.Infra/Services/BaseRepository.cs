using Guide.Variacao.Core.DataBase.Repository;
using Guide.Variacao.Seed.Infra.Context;

namespace Guide.Variacao.Seed.Infra.Services
{
    public class BaseRepository<T> : Repository<T> where T : class
    {
        public BaseRepository(GuideVariacaoContext _context) : base(_context)
        {
        }
    }
}
