using ConnectSea.Crud.Domain.Command;
using ConnectSea.Crud.Domain.Dto;
using ConnectSea.Crud.Domain.Entity;

namespace ConnectSea.Crud.Application.Mappers
{
    public static class ManifestoMapper
    {
        public static Manifesto ToEntity(ManifestoCommand command)
            => new Manifesto(command);

        public static ManifestoDto ToDto(Manifesto entity)
            => new ManifestoDto
            {
                Id = entity.Id,
                Numero = entity.Numero,
                Tipo = entity.Tipo,
                Navio = entity.Navio,
                PortoOrigem = entity.PortoOrigem,
                PortoDestino = entity.PortoDestino,
                //Escalas = entity.ManifestoEscalas.Select(x => EscalaMapper.ToDto(x.Escala)).ToList()
            };

        public static List<ManifestoDto> ToDtoList(IEnumerable<Manifesto> entities)
            => entities.Select(ToDto).ToList();
    }
}