using ASPWebApplication.Models;

namespace ASPWebApplication.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update (Category category);
       
    }
}
