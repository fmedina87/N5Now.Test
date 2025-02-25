using Microsoft.Extensions.Options;
using N5Now.Test.Domain.Common.Entities;
using N5Now.Test.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5Now.Test.Domain.Interfaces.Services
{
    public interface IElasticSearchService
    {
        Task<bool> IndexPermissionAsync(Permission permission);
        Task<List<Permission>> GetPermissionsAsync(int page, int pageSize);
        Task<bool> UpdatePermissionAsync(Permission permission);
        Task<int> Count();
    }
}
