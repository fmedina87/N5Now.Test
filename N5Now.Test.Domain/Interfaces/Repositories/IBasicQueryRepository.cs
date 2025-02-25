using N5Now.Test.Domain.Entities;

namespace N5Now.Test.Domain.Interfaces.Repositories
{
    public interface IBasicQueryRepository<T>
    {
        Task<T?> GetById(int id);
        Task<bool> Exist(int id);
    }
}
