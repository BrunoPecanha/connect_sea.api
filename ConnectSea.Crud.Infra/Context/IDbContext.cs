using ConnectSea.Crud.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace ConnectSea.Crud.Infra.Context
{
    public interface IDbContext
    {
        DbSet<Manifesto> Manifesto { get; }
        DbSet<Escala> Escala { get; }
        DbSet<Escala> ManifestoEscalas { get; }
        
        int SaveChanges();
    }
}