using ConnectSea.Crud.Domain.Command;
using ConnectSea.Crud.Domain.Dto;
using ConnectSea.Crud.Domain.Dto.Results;

namespace ConnectSea.Crud.Domain.Service
{
    public interface IManifestoService
    {
        Task<PagedResult<ManifestoDto>> GetAllPagedAsync(int pg, int size);
        Task<ManifestoDto> GetByIdAsync(int id);
        Task CreateAsync(ManifestoCommand dto);
        Task UpdateAsync(int id, ManifestoCommand command);
        Task UpdateEscalas(int id, ManifestoEditCommand command);
        Task DeleteAsync(int id);
    }
}