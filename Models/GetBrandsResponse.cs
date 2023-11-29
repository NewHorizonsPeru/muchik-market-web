namespace muchik.market.web.Models
{
	public partial class GetBrandsResponse
	{
		public bool Success { get; set; }
		public string Message { get; set; } = null!;
		public List<Brand> Data { get; set; } = null!;
	}
}
