using ASPWebApplication.Data;
using ASPWebApplication.Models;
using ASPWebApplication.Repository.IRepository;

namespace ASPWebApplication.Repository
{
	public class ProductRepository : Repository<Product>, IProductRepository
	{
		ApplicationDbContext _context;
		public ProductRepository(ApplicationDbContext context) : base(context)
		{
			_context = context;

		}

		public void Update(Product product)
		{
			var dbProduct = _context.Products.FirstOrDefault(p => p.Id == product.Id);
			if (dbProduct != null) { 
				dbProduct.Title = product.Title;
				dbProduct.Description = product.Description;
				dbProduct.ListPrice = product.ListPrice;
				dbProduct.Director = product.Director;
				dbProduct.Price50 = product.Price50;
				dbProduct.Price = product.Price;
				dbProduct.CategoryId = product.CategoryId;

				if (product.ImageUrl != null)
				{
					dbProduct.ImageUrl = product.ImageUrl;
				}
			}
				
		}
	}
}
