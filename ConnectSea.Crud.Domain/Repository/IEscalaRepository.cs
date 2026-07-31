using ConnectSea.Crud.Domain.Dto;
using ConnectSea.Crud.Domain.Dto.Results;
using ConnectSea.Crud.Domain.Entity;

namespace ConnectSea.Crud.Domain.Repository
{
    public interface IEscalaRepository : IRepositoryBase<Escala>
    {
        public Task<List<EscalaAssociacaoDto>> GetEscalasByManifestoId(int id);
        public Task<PagedResult<Escala>> GetPagedAsync(int page, int size);
    }
}