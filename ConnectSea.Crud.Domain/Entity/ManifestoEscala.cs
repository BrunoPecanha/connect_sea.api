using ConnectSea.Crud.Domain.Entity;

public class ManifestoEscala
{
    public int ManifestoId { get; private set; }
    public Manifesto Manifesto { get; private set; }

    public int EscalaId { get; private set; }
    public Escala Escala { get; private set; }

    private ManifestoEscala() { }

    public ManifestoEscala(int manifestoId, int escalaId)
    {
        ManifestoId = manifestoId;
        EscalaId = escalaId;
    }
}