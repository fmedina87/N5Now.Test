using System.ComponentModel.DataAnnotations.Schema;

namespace N5Now.Test.Domain.Entities
{
    public class PermissionType : BaseEntity
    {
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }= string.Empty;
        public ICollection<Permission> Permissions { get; set; } = new List<Permission>();
    }
}
