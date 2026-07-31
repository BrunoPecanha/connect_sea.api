using ConnectSea.Crud.Domain.Command;
using ConnectSea.Crud.Domain.Dto;
using ConnectSea.Crud.Domain.Dto.Results;
using ConnectSea.Crud.Domain.Entity;
using ConnectSea.Crud.Domain.Exceptions;
using ConnectSea.Crud.Domain.Mappers;
using ConnectSea.Crud.Domain.Repository;
using ConnectSea.Crud.Domain.Service;

namespace ConnectSea.Crud.Application
{
    public class EscalaService : IEscalaService
    {
        private readonly IEscalaRepository _repository;
        private readonly IManifestoEscalaRepository _manifestoEscalaRepository;

        public EscalaService(IEscalaRepository repository, IManifestoEscalaRepository manifestoEscalaRepository)
        {
            _repository = repository;
            _manifestoEscalaRepository = manifestoEscalaRepository;
        }   

        public async Task<PagedResult<EscalaDto>> GetAllPagedAsync(int pg, int size)
        {
            var pagedContacts = await _repository.GetPagedAsync(pg, size);

            return new PagedResult<EscalaDto>
            {
                Data = pagedContacts.Data.Select(e => EscalaMapper.ToDto(e)).ToList(),
                TotalItems = pagedContacts.TotalItems,
                Page = pagedContacts.Page,
                PageSize = pagedContacts.PageSize
            };
        }

        public async Task<EscalaDto?> GetByIdAsync(int id)
        {
            Escala escala = await _repository.GetByIdAsync(id);

            if (escala == null)
                throw new NotFoundException("Escala não encontrada");

            return EscalaMapper.ToDto(escala);
        }


        public async Task<List<EscalaAssociacaoDto>> GetEscalasByManifestoId(int id)
        {
            var escalas = await _repository.GetEscalasByManifestoId(id);

            if (escalas == null)
                throw new NotFoundException("Manifesto não encontrado");

            return escalas;
        }


        public async Task CreateAsync(EscalaCommand command)
        {
            var escala = EscalaMapper.ToEntity(command);

            await _repository.AddAsync(escala);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var contact = await _repository.GetByIdAsync(id);

            if (contact == null)
                throw new NotFoundException("Escala não encontrada");

            _repository.Remove(contact);
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, EscalaCommand command)
        {
            var escala = await _repository.GetByIdAsync(id);

            if (escala == null)
                throw new NotFoundException("Escala  não encontrada");

            escala.Update(command);

            _repository.Update(escala);
            await _repository.SaveChangesAsync();
        }
    }
}