using Newtonsoft.Json;

namespace N5Now.Test.Domain.Entities
{
    public class Permission : BaseEntity
    {
        public int EmployeeId { get; set; }
        public int PermissionTypeId { get; set; }
        [JsonIgnore]
        public PermissionType? PermissionType { get; set; }
        [JsonIgnore]
        public Employee? Employee { get; set; } = null;
    }
}
