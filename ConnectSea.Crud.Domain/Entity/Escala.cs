using ConnectSea.Crud.Domain.Command;
using ConnectSea.Crud.Domain.Enum;
using ConnectSea.Crud.Domain.Exceptions;

namespace ConnectSea.Crud.Domain.Entity;

public class Escala : BaseEntity
{
    public string Navio { get; private set; }
    public string Porto { get; private set; }
    public EscalaStatusEnum Status { get; private set; }
    public DateTimeOffset Eta { get; private set; }
    public DateTimeOffset? Etb { get; private set; }
    public DateTimeOffset? Etd { get; private set; }

    public ICollection<ManifestoEscala> ManifestoEscalas { get; private set; } = [];

    private Escala()
    {
    }

    public Escala(EscalaCommand command)
    {
        SetNavio(command.Navio);
        SetPorto(command.Porto);
        SetStatus(command.Status);
        SetEta(command.Eta);

        Etb = command.Etb;
        Etd = command.Etd;
    }

    public static Escala CreateFromSeed(int id, EscalaCommand command)
    {
        var escala = new Escala(command)
        {
            Id = id
        };

        return escala;
    }

    public void Update(EscalaCommand command)
    {
        SetNavio(command.Navio);
        SetPorto(command.Porto);
        SetStatus(command.Status);
        SetEta(command.Eta);

        Etb = command.Etb;
        Etd = command.Etd;
    }

    private void SetNavio(string navio)
    {
        if (string.IsNullOrWhiteSpace(navio))
            throw new DomainException("Navio é obrigatório.");

        Navio = navio;
    }

    private void SetPorto(string porto)
    {
        if (string.IsNullOrWhiteSpace(porto))
            throw new DomainException("Porto é obrigatório.");

        Porto = porto;
    }

    private void SetStatus(EscalaStatusEnum status)
    {
        Status = status;
    }

    private void SetEta(DateTimeOffset eta)
    {
        if (eta == default)
            throw new DomainException("ETA é obrigatório.");

        Eta = eta;
    }
}