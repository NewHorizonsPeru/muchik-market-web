namespace muchik.market.web.Models
{
	public partial class GetCategoriesResponse
	{
		public bool Success { get; set; }
		public string Message { get; set; } = null!;
		public List<Category> Data { get; set; } = null!;
	}
}
