using ConnectSea.Crud.Domain.Dto;
using ConnectSea.Crud.Domain.Dto.Results;
using ConnectSea.Crud.Domain.Entity;
using ConnectSea.Crud.Domain.Enum;
using ConnectSea.Crud.Domain.Repository;
using ConnectSea.Crud.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace ConnectSea.Crud.Infra.Repository
{
    public class EscalaRepository : RepositoryBase<Escala>, IEscalaRepository
    {
        private readonly DbCtx _context;

        public EscalaRepository(DbCtx context)
          : base(context)
        {
            _context = context;
        }

        public async Task<List<EscalaAssociacaoDto>> GetEscalasByManifestoId(int manifestoId)
        {
            return await _context.Escala
                .Select(e => new EscalaAssociacaoDto
                {
                    Id = e.Id,
                    Porto = e.Porto,
                    Selecionado = e.ManifestoEscalas.Any(me => me.ManifestoId == manifestoId),
                    Cancelado = e.Status == EscalaStatusEnum.CANCELADA
                })
                .OrderBy(e => e.Porto)
                .ToListAsync();
        }

        public async Task<PagedResult<Escala>> GetPagedAsync(int page, int size)
        {
            var query = _context.Escala
                .Include(x => x.ManifestoEscalas)
                    .ThenInclude(x => x.Manifesto)
                .OrderBy(x => x.Porto);

            var total = await query.CountAsync();

            var data = await query
                .Skip((page - 1) * size)
                .Take(size)
                .ToListAsync();

            return new PagedResult<Escala>
            {
                Data = data,
                TotalItems = total,
                Page = page,
                PageSize = size
            };
        }
    }
}