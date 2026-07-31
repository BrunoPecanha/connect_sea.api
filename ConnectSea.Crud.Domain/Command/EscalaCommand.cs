using ConnectSea.Crud.Domain.Enum;

namespace ConnectSea.Crud.Domain.Command
{
    public class EscalaCommand
    {
        public int Id { get; set; } 
        public string Navio { get; set; }
        public string Porto { get; set; }
        public EscalaStatusEnum Status { get; set; }
        public DateTimeOffset Eta { get; set; }
        public DateTimeOffset? Etb { get; set; }
        public DateTimeOffset? Etd { get; set; }
    }
}