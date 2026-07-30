using ConnectSea.Crud.Domain.Entity;
using ConnectSea.Crud.Domain.Repository;
using ConnectSea.Crud.Infra.Context;

namespace ConnectSea.Crud.Infra.Repository
{
    public class ManifestoRespository : RepositoryBase<Manifesto>, IManifestoRepository
    {
        private readonly DbCtx _context;

        public ManifestoRespository(DbCtx context)
          : base(context)
        {
            _context = context;
        }       
    }
}