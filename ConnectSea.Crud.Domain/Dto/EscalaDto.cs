using ConnectSea.Crud.Domain.Enum;
using System.Text.Json.Serialization;

namespace ConnectSea.Crud.Domain.Dto
{
    public class EscalaDto
    {
        public int Id { get; set; }
        public string Navio { get; set; }
        public string Porto { get; set; }
        public EscalaStatusEnum Status { get; set; }

        public DateTimeOffset Eta { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTimeOffset? Etb { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTimeOffset? Etd { get; set; }
    }
}