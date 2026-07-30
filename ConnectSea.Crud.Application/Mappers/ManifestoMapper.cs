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
                //Id = entity.Id,
                //Name = entity.Name,
                //BirthDate = entity.BirthDate,
                //Sex = entity.Sex
            };

        public static ManifestoDto ToDto(int id, string name)
           => new ManifestoDto
           {
               //Id = id,
               //Name = name
           };
    }
}