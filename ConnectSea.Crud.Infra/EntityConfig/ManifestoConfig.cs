using ConnectSea.Crud.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConnectSea.Crud.Infra.EntityConfig
{
    public class ManifestoConfig : IEntityTypeConfiguration<Manifesto>
    {
        public void Configure(EntityTypeBuilder<Manifesto> builder)
        {
            builder.ToTable("manifestos");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Numero)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(x => x.Tipo)
                .IsRequired();

            builder.Property(x => x.Navio)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.PortoOrigem)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.PortoDestino)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasIndex(x => x.Numero)
               .IsUnique();
        }
    }
}