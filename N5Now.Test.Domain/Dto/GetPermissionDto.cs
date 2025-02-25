using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5Now.Test.Domain.Dto
{
    public class GetPermissionDto: BasicPermissionDto
    {
        public int Id { get; set; }
        public string PermissionType { get; set; } = string.Empty;
        public string Employee {  get; set; }= string.Empty;
        public bool IsActive { get; set; }
    }
}
