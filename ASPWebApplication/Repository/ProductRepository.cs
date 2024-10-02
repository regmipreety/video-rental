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
            _context.Products.Update(product);
        }
    }
}
