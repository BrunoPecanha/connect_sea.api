using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConnectSea.Crud.Infra.EntityConfig
{
    public class ManifestoEscalaConfig : IEntityTypeConfiguration<ManifestoEscala>
    {
        public void Configure(EntityTypeBuilder<ManifestoEscala> builder)
        {
            builder.ToTable("manifesto_escalas");

            builder.HasKey(x => new
            {
                x.ManifestoId,
                x.EscalaId
            });

            //builder.HasOne(x => x.Manifesto)
            //    .WithMany(x => x.ManifestoEscalas)
            //    .HasForeignKey(x => x.ManifestoId);

            //builder.HasOne(x => x.Escala)
            //    .WithMany(x => x.ManifestoEscalas)
            //    .HasForeignKey(x => x.EscalaId);
        }
    }
}