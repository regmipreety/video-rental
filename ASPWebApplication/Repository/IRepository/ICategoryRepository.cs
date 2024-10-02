using ASPWebApplication.Areas.Admin.Models;

namespace ASPWebApplication.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update (Category category);
       
    }
}
