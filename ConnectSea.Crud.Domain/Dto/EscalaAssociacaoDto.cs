namespace ConnectSea.Crud.Domain.Dto
{
    public class EscalaAssociacaoDto
    {
        public int Id { get; set; }
        public string Porto { get; set; }
        public bool Selecionado { get; set; }
        public bool Cancelado { get; set; }
        public DateTimeOffset Data { get; set; }
    }
}