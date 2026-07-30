using ConnectSea.Crud.Domain.Command;
using ConnectSea.Crud.Domain.Dto;
using ConnectSea.Crud.Domain.Dto.Results;
using ConnectSea.Crud.Domain.Entity;

namespace ConnectSea.Crud.Domain.Service
{
    public interface IManifestoService
    {
        Task<PagedResult<ManifestoDto>> GetAllPagedAsync(int pg, int size);
        Task<Manifesto?> GetByIdAsync(int id);
        Task CreateAsync(ManifestoCommand dto);
        Task UpdateAsync(int id, ManifestoCommand command);
        Task DeleteAsync(int id);
    }
}