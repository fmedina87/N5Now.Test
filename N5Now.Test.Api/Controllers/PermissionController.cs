using Microsoft.AspNetCore.Mvc;
using N5Now.Test.Domain.Common.Filters;
using N5Now.Test.Domain.Common.Reponses;
using N5Now.Test.Domain.Dto;
using N5Now.Test.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using N5Now.Test.Domain.Interfaces.Services;
namespace N5Now.Test.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController(IPermissionService service) : ControllerBase
    {
        private readonly IPermissionService _service = service;

        /// <summary>
        /// Add a permission
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiReponse<int>> Add(AddPermissionDto request)
        {
            return await _service.Add(request);
        }
        /// <summary>
        /// get a list of permissions
        /// </summary>
        /// <param name="page">pagea number</param>
        /// <param name="pageSize">page size</param>
        /// <returns></returns>
        [HttpGet]
        public async  Task<ApiReponse<GetPermissionDto>> GetAll([FromQuery] [Required] int page, [Required] int pageSize)
        {
            return await _service.GetAll(page, pageSize);
        }
        /// <summary>
        /// update a permission
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPatch]
        public Task<ApiReponse<bool>> Update(UpdatePermissionDto request)
        {
            return _service.Update(request);
        }
    }
}
