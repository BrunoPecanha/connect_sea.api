namespace ConnectSea.Crud.Domain.Mappers
{
    public static class ManifestoEscalaMapper
    {
        public static ManifestoEscala ToEntity(int manifestoId, int escalaId)
           => new ManifestoEscala(manifestoId, escalaId);               
    }
}