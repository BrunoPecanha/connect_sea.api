using ConnectSea.Crud.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConnectSea.Crud.Infra.EntityConfig
{
    public class EscalaConfig : IEntityTypeConfiguration<Escala>
    {
        public void Configure(EntityTypeBuilder<Escala> builder)
        {
            builder.ToTable("escalas");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Navio)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Porto)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Status)
                .IsRequired();

            builder.Property(x => x.Eta)
                .IsRequired();

            builder.Property(x => x.Etb);

            builder.Property(x => x.Etd);
        }
    }
}