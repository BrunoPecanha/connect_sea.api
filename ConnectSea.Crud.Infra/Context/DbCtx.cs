using ConnectSea.Crud.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace ConnectSea.Crud.Infra.Context
{
    public class DbCtx : DbContext
    {
        public DbCtx(DbContextOptions<DbCtx> options)
            : base(options)
        {
        }

        public DbSet<Manifesto> Manifesto { get; set; }
        public DbSet<Escala> Escala { get; set; }
        public DbSet<ManifestoEscala> ManifestoEscalas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DbCtx).Assembly);
        }
    }
}