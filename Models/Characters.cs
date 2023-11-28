namespace muchik.market.web.Models
{
    public partial class Characters
    {
        public List<Result> Results { get; set; } = null!;
    }

    public partial class Result
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Type { get; set; } = null!;
        public string Image { get; set; } = null!;
    }
}
