using N5Now.Test.Domain.Common.Exceptions;
using N5Now.Test.Domain.Common.Reponses;
using N5Now.Test.Domain.Dto;
using N5Now.Test.Domain.Entities;
using N5Now.Test.Domain.Interfaces.Repositories;
using N5Now.Test.Domain.Interfaces.Services;
using System.Security;

namespace N5Now.Test.Application.Services
{
    public class PermissionService(IUnitOfWork unitOfwork, ILoggerService logger, IElasticSearchService elasticSearchService, IKafkaProducerService kafkaProducer ): IPermissionService
    {
        private readonly IUnitOfWork _unitOfwork = unitOfwork;
        private readonly ILoggerService _logger = logger;
        private readonly IElasticSearchService _elasticSearchService = elasticSearchService;
        private readonly IKafkaProducerService _kafkaProducer = kafkaProducer;
        public async Task<ApiReponse<int>> Add(AddPermissionDto request)
        {

            _logger.LogInformation("start method");
            await ValidateAddData(request);
            Permission permission = Cast(request);
            await _unitOfwork.Permission.Add(permission);
            int idPermission = await _unitOfwork.SaveChangesAsync();
            await _elasticSearchService.IndexPermissionAsync(permission);
            await SendMessage("request");
            var response = new ApiReponse<int>()
            {
                Result = idPermission,
            };
            _logger.LogInformation("end method");
            return response;
        }
        private async Task SendMessage(string operationName)
        {
            KafkaDtoMessage message = new(operationName);
            await _kafkaProducer.SendMessageAsync(message);
        }
        public async Task<ApiReponse<bool>> Update(UpdatePermissionDto request)
        {
            var isUpadated = false;
            _logger.LogInformation("start method");
            await ValidateUpdateData(request);
            Permission? permission = await _unitOfwork.Permission.GetById(request.Id) ?? throw new ApiException("the permission does not exist");
            SetChagesToUpdate(request, permission);
            _unitOfwork.Permission.Update(permission);
            int result = await _unitOfwork.SaveChangesAsync();
            if (result >= 0)
            {
                isUpadated = true;
                await _elasticSearchService.UpdatePermissionAsync(permission);
                await SendMessage("modify");
            }
            var response = new ApiReponse<bool>()
            {
                Result = isUpadated,
            };
            _logger.LogInformation("end method");
            return response;
        }
        public async Task<ApiReponse<GetPermissionDto>> GetAll(int page, int pageSize)
        {
            _logger.LogInformation("start method");
            var count = await _elasticSearchService.Count();
            var list= await _elasticSearchService.GetPermissionsAsync(page, pageSize);            
            //var list = await _unitOfwork.Permission.GetAllPaginated(page, pageSize);
            List<GetPermissionDto> listDto = Cast(list);
            var pagedList = new PagedResult<GetPermissionDto>(listDto, count, page, pageSize);
            var response = new ApiReponse<GetPermissionDto>()
            {
                Data = pagedList
            };
            await SendMessage("get");
            _logger.LogInformation("end method");
            return response;
        }

        private static Permission Cast(AddPermissionDto permissionDto)
        {
            Permission permission = new()
            {
                EmployeeId = permissionDto.EmployeeId,
                IsActive = true,
                CreatedDate = DateTime.Now,
                PermissionTypeId = permissionDto.PermissionTypeId
            };
            return permission;
        }
        private static List<GetPermissionDto> Cast(List<Permission> list)
        {
            List<GetPermissionDto> listDto = [];
            foreach (Permission item in list)
            {
                listDto.Add(Cast(item));
            }
            return listDto;
        }
        private static GetPermissionDto Cast(Permission permission)
        {
            GetPermissionDto permissionDto = new()
            {
                Id = permission.Id,
                EmployeeId = permission.EmployeeId,
                PermissionTypeId = permission.PermissionTypeId,
                Employee = $"{permission.Employee?.FirstName} {permission.Employee?.SecondName} {permission.Employee?.FirstLastName} {permission.Employee?.SecondLastName}",
                PermissionType = $"{permission.PermissionType?.Name}",
                IsActive = permission.IsActive,

            };
            return permissionDto;
        }
        private static void SetChagesToUpdate(UpdatePermissionDto permissionDto, Permission permission)
        {
            if (permissionDto.EmployeeId > 0)
                permission.EmployeeId = permissionDto.EmployeeId;
            if (permissionDto.PermissionTypeId > 0)
                permission.PermissionTypeId = permissionDto.PermissionTypeId;
            permission.IsActive = permissionDto.IsActive;
            permission.UpdatedDate = DateTime.Now;

        }
        private async Task ValidateBasicAddData(BasicPermissionDto request)
        {
            if (request.EmployeeId <= 0)
                throw new ApiException("invalid employee ID,value not allowed");
            if (request.PermissionTypeId <= 0)
                throw new ApiException("invalid permission type ID, value not allowed");
            bool exist = await _unitOfwork.Employee.Exist(request.EmployeeId);
            if (!exist)
                throw new ApiException("invalid employee ID");
            exist = await _unitOfwork.PermissionType.Exist(request.PermissionTypeId);
            if (!exist)
                throw new ApiException("invalid permission type ID");
        }
        private async Task ValidateAddData(AddPermissionDto request)
        {
            try
            {
                await ValidateBasicAddData(request);
                bool exist = await _unitOfwork.Permission.Exist(request.EmployeeId, request.PermissionTypeId);
                if (exist)
                    throw new ApiException("the permission you are trying to create already exists");
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }
        private async Task ValidateUpdateData(UpdatePermissionDto request)
        {
            if (request.Id <= 0)
                throw new ApiException("the permission you are trying to update not exists");
            await ValidateBasicAddData(request);
            var permission = await _unitOfwork.Permission.GetByEmployeeIdAndPermissionTypeId(request.EmployeeId, request.PermissionTypeId);
            if (permission != null && permission.Id != request.Id)
                throw new ApiException("the permission you are trying to update already exists");
        }
    }
}
