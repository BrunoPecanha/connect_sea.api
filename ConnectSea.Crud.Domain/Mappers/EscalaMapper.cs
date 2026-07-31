using ConnectSea.Crud.Domain.Command;
using ConnectSea.Crud.Domain.Dto;
using ConnectSea.Crud.Domain.Entity;

namespace ConnectSea.Crud.Domain.Mappers
{
    public static class EscalaMapper
    {
        public static Escala ToEntity(EscalaCommand command)
            => new Escala(command);

        public static EscalaDto ToDto(Escala escala)
        {
            return new EscalaDto
            {
                Id = escala.Id,
                Porto = escala.Porto,
                Status = escala.Status,
                Eta = escala.Eta,
                Etb = escala.Etb,
                Etd = escala.Etd,

                Manifestos = escala.ManifestoEscalas
                    .Select(x => new ManifestoResumoDto
                    {
                        Id = x.Manifesto.Id,
                        Numero = x.Manifesto.Numero
                    })
                    .ToList()
            };
        }

        public static List<EscalaDto> ToDtoList(IEnumerable<Escala> entities)
            => entities.Select(ToDto).ToList();
    }
}