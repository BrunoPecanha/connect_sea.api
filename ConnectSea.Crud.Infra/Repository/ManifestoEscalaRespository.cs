using ConnectSea.Crud.Domain.Repository;
using ConnectSea.Crud.Infra.Context;

namespace ConnectSea.Crud.Infra.Repository
{
    public class ManifestoEscalaRespository : IManifestoEscalaRepository
    {
        private readonly DbCtx _context;

        public ManifestoEscalaRespository(DbCtx context)
        {
            _context = context;
        }       
    }
}