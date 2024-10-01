using ASPWebApplication.Data;
using ASPWebApplication.Models;
using ASPWebApplication.Repository.IRepository;

namespace ASPWebApplication.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _context;

        public ICategoryRepository Category {  get; private set; }
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Category = new CategoryRepository(_context);
        }
        public ICategoryRepository CategoryRepository { get; private set; }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
