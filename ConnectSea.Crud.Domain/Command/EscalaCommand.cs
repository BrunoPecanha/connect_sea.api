using ConnectSea.Crud.Domain.Enum;

namespace ConnectSea.Crud.Domain.Command
{
    public class EscalaCommand
    {
        public string Navio { get; set; }
        public string Porto { get; set; }
        public EscalaStatusEnum Status { get; set; }
        public DateTime Eta { get; set; }
        public DateTime? Etb { get; set; }
        public DateTime? Etd { get; set; }
    }
}