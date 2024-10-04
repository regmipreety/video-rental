using ASPWebApplication.Models;

namespace ASPWebApplication.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update (Product product);
    }
}
