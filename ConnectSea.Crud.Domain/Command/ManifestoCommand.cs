using ConnectSea.Crud.Domain.Enum;

namespace ConnectSea.Crud.Domain.Command
{
    public class ManifestoCommand
    {
        public string Numero { get; set; }
        public ManifestoTipoEnum Tipo { get; set; }
        public string Navio { get; set; }
        public string PortoOrigem { get; set; }
        public string PortoDestino { get; set; }
        public int[] Escalas { get; set; }
    }
}