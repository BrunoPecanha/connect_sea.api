using System.Text.Json;
using ConnectSea.Crud.Domain.Command;
using ConnectSea.Crud.Domain.Dto;
using ConnectSea.Crud.Domain.Entity;
using ConnectSea.Crud.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace ConnectSea.Crud.Infra.Seed;

public static class SeedData
{
    public static async Task InitializeAsync(DbCtx context, string contentRootPath)
    {
        await context.Database.MigrateAsync();

        if (await context.Manifesto.AnyAsync())
            return;

        await SeedManifestos(context, contentRootPath);
        await SeedEscalas(context, contentRootPath);

        await context.SaveChangesAsync();

        await SeedManifestoEscalas(context);

        await context.SaveChangesAsync();
    }

    private static async Task SeedManifestos(DbCtx context, string contentRootPath)
    {
        var path = Path.Combine(contentRootPath, "Seed", "manifestos.json");
        var dtos = await ReadJsonAsync<ManifestoDto>(path);

        foreach (var dto in dtos)
        {
            var manifesto = Manifesto.CreateFromSeed(dto.Id,
                      new ManifestoCommand
                      {
                          Numero = dto.Numero,
                          Tipo = dto.Tipo,
                          Navio = dto.Navio,
                          PortoOrigem = dto.PortoOrigem,
                          PortoDestino = dto.PortoDestino
                      });

            context.Manifesto.Add(manifesto);
        }
    }

    private static async Task SeedEscalas(DbCtx context, string contentRootPath)
    {
        var path = Path.Combine(contentRootPath, "Seed", "escalas.json");

        var dtos = await ReadJsonAsync<EscalaDto>(path);

        foreach (var dto in dtos)
        {
            var escala = Escala.CreateFromSeed(dto.Id,
                     new EscalaCommand
                     {
                         Navio = dto.Navio,
                         Porto = dto.Porto,
                         Status = dto.Status,
                         Eta = dto.Eta,
                         Etb = dto.Etb,
                         Etd = dto.Etd
                     });

            context.Escala.Add(escala);
        }
    }

    private static async Task SeedManifestoEscalas(DbCtx context)
    {
        var manifestos = await context.Manifesto.AsNoTracking().ToListAsync();
        var escalas = await context.Escala.AsNoTracking().ToListAsync();

        foreach (var manifesto in manifestos)
        {
            var escalasDoNavio = escalas.Where(e => string.Equals(e.Navio, manifesto.Navio, StringComparison.OrdinalIgnoreCase));

            foreach (var escala in escalasDoNavio)
            {
                context.ManifestoEscalas.Add(new ManifestoEscala(manifesto.Id, escala.Id));
            }
        }
    }

    private static async Task<List<T>> ReadJsonAsync<T>(string path)
    {
        if (!File.Exists(path))
            throw new FileNotFoundException($"Arquivo de seed não encontrado: {path}");

        var json = await File.ReadAllTextAsync(path);

        return JsonSerializer.Deserialize<List<T>>(json,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }) ?? [];
    }
}