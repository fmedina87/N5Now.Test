using N5Now.Test.Domain.Common.Reponses;
using N5Now.Test.Domain.Dto;
using N5Now.Test.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5Now.Test.Domain.Interfaces.Services
{
    public interface IPermissionService
    {
        Task<ApiReponse<int>> Add(AddPermissionDto request);
        Task<ApiReponse<bool>> Update(UpdatePermissionDto request);
        Task<ApiReponse<GetPermissionDto>> GetAll(int page, int pageSize);
    }
}
