using N5Now.Test.Infrastructure.Data;

namespace N5Now.Test.Infrastructure.Repositories
{
    public class BasicQuerysRepository<T>(ApplicationDbContext context) where T : class
    {
        private readonly ApplicationDbContext _context = context;
        public async Task<T?> GetById(int id)
        {
            var entities = _context.Set<T>();
            return await entities.FindAsync(id);
        }
        public async Task<bool> Exist(int id)
        {
            var entities = _context.Set<T>();
            var entity = await entities.FindAsync(id);
            if (entity != null)
                return true;
            else return false;
        }
    }
}
