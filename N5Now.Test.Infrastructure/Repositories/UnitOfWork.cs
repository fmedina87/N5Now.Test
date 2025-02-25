using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Options;
using N5Now.Test.Domain.Common.Entities;
using N5Now.Test.Domain.Entities;
using N5Now.Test.Domain.Interfaces.Repositories;
using N5Now.Test.Infrastructure.Data;

namespace N5Now.Test.Infrastructure.Repositories
{
    public class UnitOfWork(ApplicationDbContext context, IOptions<AppSettings> appSettings, IPermissionTypeRepository permissionType,
        IEmployeeRepository employee, IPermissionRepository permission) : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext = context;
        private readonly IOptions<AppSettings> _appSettings = appSettings;
        #region Repositories
        public IPermissionTypeRepository PermissionType { get; } = permissionType;
        public IEmployeeRepository Employee { get; }= employee;
        public IPermissionRepository Permission { get; } = permission;
        #endregion
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            _dbContext?.Dispose();
        }
        public void SaveChanges()
        {
            _dbContext?.SaveChanges();
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
        public DatabaseFacade Database
        {
            get { return _dbContext.Database; }
        }
    }
}
