using ConnectSea.Crud.Domain.Enum;

namespace ConnectSea.Crud.Domain.Dto
{
    public class ManifestoDto
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public ManifestoTipoEnum Tipo { get; set; }
        public string Navio { get; set; }
        public string PortoOrigem { get; set; }
        public string PortoDestino { get; set; }
    }
}