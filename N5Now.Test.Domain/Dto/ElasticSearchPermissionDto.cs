using N5Now.Test.Domain.Entities;

namespace N5Now.Test.Domain.Dto
{
    public class ElasticSearchPermissionDto : BaseEntity
    {
        public int EmployeeId { get; set; }
        public int PermissionTypeId { get; set; }
    }
}
