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

        //public async Task<Manifesto> GetCompleteById(int id)
        //{
        //    var manifestos = await _context.Manifesto
        //            .Include(x => x.ManifestoEscalas)
        //                .ThenInclude(x => x.Escala)
        //            .FirstOrDefaultAsync();

        //    return manifestos;
        //}
    }
}