using ConnectSea.Crud.Domain.Command;
using ConnectSea.Crud.Domain.Enum;
using ConnectSea.Crud.Domain.Exceptions;

namespace ConnectSea.Crud.Domain.Entity;

public class Manifesto : BaseEntity
{
    public string Numero { get; private set; }
    public ManifestoTipoEnum Tipo { get; private set; }
    public string Navio { get; private set; }
    public string PortoOrigem { get; private set; }
    public string PortoDestino { get; private set; }

    public ICollection<ManifestoEscala> ManifestoEscalas { get; private set; } = [];

    private Manifesto()
    {
    }

    public Manifesto(ManifestoCommand command)
    {
        SetNumero(command.Numero);
        SetTipo(command.Tipo);
        SetNavio(command.Navio);
        SetPortoOrigem(command.PortoOrigem);
        SetPortoDestino(command.PortoDestino);
    }

    public static Manifesto CreateFromSeed(int id, ManifestoCommand command)
    {
        var manifesto = new Manifesto(command)
        {
            Id = id
        };

        return manifesto;
    }

    public void Update(ManifestoCommand command)
    {
        SetNumero(command.Numero);
        SetTipo(command.Tipo);
        SetNavio(command.Navio);
        SetPortoOrigem(command.PortoOrigem);
        SetPortoDestino(command.PortoDestino);
    }

    public void AdicionarEscala(int escalaId)
    {
        if (ManifestoEscalas.Any(x => x.EscalaId == escalaId))
            return;

        ManifestoEscalas.Add(
            new ManifestoEscala(Id, escalaId));
    }

    private void SetNumero(string numero)
    {
        if (string.IsNullOrWhiteSpace(numero))
            throw new DomainException("Número é obrigatório.");

        Numero = numero;
    }

    private void SetTipo(ManifestoTipoEnum tipo)
    {
        Tipo = tipo;
    }

    private void SetNavio(string navio)
    {
        if (string.IsNullOrWhiteSpace(navio))
            throw new DomainException("Navio é obrigatório.");

        Navio = navio;
    }

    private void SetPortoOrigem(string portoOrigem)
    {
        if (string.IsNullOrWhiteSpace(portoOrigem))
            throw new DomainException("Porto origem é obrigatório.");

        PortoOrigem = portoOrigem;
    }

    private void SetPortoDestino(string portoDestino)
    {
        if (string.IsNullOrWhiteSpace(portoDestino))
            throw new DomainException("Porto destino é obrigatório.");

        PortoDestino = portoDestino;
    }
}