using N5Now.Test.Domain.Entities;

namespace N5Now.Test.Domain.Interfaces.Repositories
{
    public interface IPermissionRepository : IBasicQueryRepository<Permission>
    {
        Task Add(Permission permission);
        Task<List<Permission>> GetByEmployeeId(int employeeid);
        void Update(Permission permission);
        Task<bool> Exist(int employeeId, int permissionTypeId);
        Task<Permission?> GetByEmployeeIdAndPermissionTypeId(int employeeId, int permissionTypeId);
        Task<int> Count();
        Task<List<Permission>> GetAllPaginated(int page, int PageSize);
    }
}
