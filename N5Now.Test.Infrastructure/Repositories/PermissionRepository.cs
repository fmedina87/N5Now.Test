using Microsoft.EntityFrameworkCore;
using N5Now.Test.Domain.Entities;
using N5Now.Test.Domain.Interfaces.Repositories;
using N5Now.Test.Infrastructure.Data;

namespace N5Now.Test.Infrastructure.Repositories
{
    public class PermissionRepository(ApplicationDbContext context) : BasicQuerysRepository<Permission>(context), IPermissionRepository
    {
        private readonly ApplicationDbContext _context = context;
        public async Task Add(Permission permissionType)
        {
            await _context.Permissions.AddAsync(permissionType);
        }
        public void Update(Permission permissionType)
        {
            _context.Permissions.Update(permissionType);
        }
        public async Task<List<Permission>> GetByEmployeeId(int employeeid)
        {
            var result = await _context.Permissions.Where(x => x.Id == employeeid).ToListAsync();
            return result;
        }
        public async Task<bool> Exist(int employeeId, int permissionTypeId)
        {
            var entity = await _context.Permissions.FirstOrDefaultAsync(x => x.EmployeeId == employeeId && x.PermissionTypeId == permissionTypeId);
            if (entity != null)
                return true;
            else return false;
        }
        public async Task<Permission?> GetByEmployeeIdAndPermissionTypeId(int employeeId, int permissionTypeId)
        {
            var entity = await _context.Permissions.FirstOrDefaultAsync(x => x.EmployeeId == employeeId && x.PermissionTypeId == permissionTypeId);
            return entity;
        }
        public async Task<int> Count()
        {
            var result = await _context.Permissions.AsQueryable().CountAsync();
            return result;
        }
        public async Task<List<Permission>> GetAllPaginated(int page, int pageSize)
        {
            return await _context.Permissions.Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Include(x=>x.PermissionType)
                .Include(y=>y.Employee)
                .ToListAsync();
        }
    }
}
