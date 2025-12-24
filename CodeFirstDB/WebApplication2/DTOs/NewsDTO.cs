namespace CodeFirstDbWebApi.DTOs
{
    public class NewsDTO
    {
        public int Id { get; set; }
        public string? Tittle { get; set; }
        public int C_id { get; set; }
        public DateOnly Date { get; set; }
    }
}
