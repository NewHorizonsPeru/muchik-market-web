namespace muchik.market.web.Models
{
    public partial class GetCharactersResponse
    {
        public List<Character> Results { get; set; } = null!;
    }

    public partial class Character
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Type { get; set; } = null!;
        public string Image { get; set; } = null!;
    }
}
