using ConnectSea.Crud.Domain.Entity;

namespace ConnectSea.Crud.Domain.Repository
{
    public interface IManifestoRepository : IRepositoryBase<Manifesto>
    {
        Task<Manifesto> GetCompleteById(int id);
    }
}