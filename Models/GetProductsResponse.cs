namespace muchik.market.web.Models
{
	public partial class GetProductsResponse
	{
		public bool Success { get; set; }
		public string Message { get; set; } = null!;
		public List<Product> Data { get; set; } = null!;
	}

	public partial class NewProduct
	{
		public string Name { get; set; } = null!;
		public string Sku { get; set; } = null!;
		public decimal Price { get; set; }
		public string Description { get; set; } = null!;
		public string ImageUrl { get; set; } = null!;
		public int Score { get; set; }
		public int Stock { get; set; }
		public string BrandId { get; set; } = null!;
		public string CategoryId { get; set; } = null!;
	}

	public partial class Product
	{
		public string Id { get; set; } = null!;
		public string Name { get; set; } = null!;
		public string Sku { get; set; } = null!;
		public decimal Price { get; set; }
		public string Description { get; set; } = null!;
		public string ImageUrl { get; set; } = null!;
		public int Score { get; set; }
		public int Stock { get; set; }
		public Brand Brand { get; set; } = null!;
		public Category Category { get; set; } = null!;
	}

	public partial class Brand
	{
		public string Id { get; set; } = null!;
		public string Name { get; set; } = null!;
		public string Description { get; set; } = null!;
	}

	public partial class Category
	{
		public string Id { get; set; } = null!;
		public string Name { get; set; } = null!;
		public string Description { get; set; } = null!;
	}
}
