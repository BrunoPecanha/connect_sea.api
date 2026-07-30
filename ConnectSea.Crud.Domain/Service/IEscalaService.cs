using ConnectSea.Crud.Domain.Command;
using ConnectSea.Crud.Domain.Dto;
using ConnectSea.Crud.Domain.Dto.Results;

namespace ConnectSea.Crud.Domain.Service
{

    public interface IEscalaService
    {        
        Task<PagedResult<EscalaDto>> GetAllPagedAsync(int pg, int size);
        Task<EscalaDto?> GetByIdAsync(int id);
        Task CreateAsync(EscalaCommand dto);
        Task UpdateAsync(int id, EscalaCommand command);
        Task DeleteAsync(int id);
    }
}