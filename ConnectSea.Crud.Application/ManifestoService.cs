using ConnectSea.Crud.Application.Mappers;
using ConnectSea.Crud.Domain.Command;
using ConnectSea.Crud.Domain.Dto;
using ConnectSea.Crud.Domain.Dto.Results;
using ConnectSea.Crud.Domain.Entity;
using ConnectSea.Crud.Domain.Exceptions;
using ConnectSea.Crud.Domain.Repository;
using ConnectSea.Crud.Domain.Service;

namespace ConnectSea.Crud.Application
{
    public class ManifestoService : IManifestoService
    {
        private readonly IManifestoRepository _repository;

        public ManifestoService(IManifestoRepository repository)
        {
            _repository = repository;
        }

        public async Task<PagedResult<ManifestoDto>> GetAllPagedAsync(int pg, int size)
        {
            var pagedContacts = await _repository.GetPagedAsync(pg, size, x => x.Navio);

            return new PagedResult<ManifestoDto>
            {
                Data = pagedContacts.Data.Select(c => ManifestoMapper.ToDto(c)).ToList(),
                TotalItems = pagedContacts.TotalItems,
                Page = pagedContacts.Page,
                PageSize = pagedContacts.PageSize
            };
        }

        public async Task<Manifesto?> GetByIdAsync(int id)
            => await _repository.GetByIdAsync(id);

        public async Task CreateAsync(ManifestoCommand command)
        {
            var contact = ManifestoMapper.ToEntity(command);

            await _repository.AddAsync(contact);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var contact = await _repository.GetByIdAsync(id);

            if (contact == null)
                throw new NotFoundException("Manifesto não encontrado");

            _repository.Remove(contact);
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, ManifestoCommand command)
        {
            var manifesto = await _repository.GetByIdAsync(id);

            if (manifesto == null)
                throw new NotFoundException("Manifesto não encontrado");

            manifesto.Update(command);

            _repository.Update(manifesto);
            await _repository.SaveChangesAsync();
        }
    }
}