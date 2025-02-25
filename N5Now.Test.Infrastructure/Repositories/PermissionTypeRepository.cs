using N5Now.Test.Domain.Entities;
using N5Now.Test.Domain.Interfaces.Repositories;
using N5Now.Test.Infrastructure.Data;

namespace N5Now.Test.Infrastructure.Repositories
{
    public class PermissionTypeRepository(ApplicationDbContext context) : BasicQuerysRepository<PermissionType>(context), IPermissionTypeRepository
    {
    }
}
