using Microsoft.EntityFrameworkCore.Infrastructure;
using N5Now.Test.Domain.Entities;

namespace N5Now.Test.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();
        Task<int> SaveChangesAsync();
        DatabaseFacade Database { get; }
        #region Repositories
        IPermissionTypeRepository PermissionType { get; }
        IEmployeeRepository Employee { get; }
        IPermissionRepository Permission { get; }
        #endregion
    }
}
