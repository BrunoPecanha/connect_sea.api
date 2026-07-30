using ConnectSea.Crud.Domain.Command;
using ConnectSea.Crud.Domain.Dto;
using ConnectSea.Crud.Domain.Entity;

namespace ConnectSea.Crud.Application.Mappers
{
    public static class EscalaMapper
    {
        public static Escala ToEntity(EscalaCommand command)
            => new Escala(command);

        public static EscalaDto ToDto(Escala entity)
            => new EscalaDto
            {
                Id = entity.Id,
                Navio = entity.Navio,
                Porto = entity.Porto,
                Status = entity.Status,
                Eta = entity.Eta,
                Etb = entity.Etb,
                Etd = entity.Etd
            };

        public static List<EscalaDto> ToDtoList(IEnumerable<Escala> entities)
            => entities.Select(ToDto).ToList();
    }
}