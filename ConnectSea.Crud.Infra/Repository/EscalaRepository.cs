using ConnectSea.Crud.Domain.Entity;
using ConnectSea.Crud.Domain.Repository;
using ConnectSea.Crud.Infra.Context;

namespace ConnectSea.Crud.Infra.Repository
{
    public class EscalaRepository : RepositoryBase<Escala>, IEscalaRepository
    {
        private readonly DbCtx _context;

        public EscalaRepository(DbCtx context)
          : base(context)
        {
            _context = context;
        }       
    }
}