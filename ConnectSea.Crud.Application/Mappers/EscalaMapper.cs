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
                //Id = entity.Id,
                //Name = entity.Name,
                //BirthDate = entity.BirthDate,
                //Sex = entity.Sex
            };

        public static EscalaDto ToDto(int id, string name)
           => new EscalaDto
           {
               //Id = id,
               //Name = name
           };
    }
}