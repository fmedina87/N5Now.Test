using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5Now.Test.Domain.Entities
{
    public class Employee: BaseEntity
    {
        [Column(TypeName = "varchar(60)")]
        public string FirstName { get; set; } = string.Empty;
        [Column(TypeName = "varchar(60)")]
        public string? SecondName { get; set; }
        [Column(TypeName = "varchar(60)")]
        public string FirstLastName { get; set; } = string.Empty;
        [Column(TypeName = "varchar(60)")]
        public string? SecondLastName { get; set; }
        [Column(TypeName = "varchar(15)")]
        public string? Code { get; set; }
        [Column(TypeName = "varchar(15)")]
        public string Identification { get; set; } = string.Empty;
        public ICollection<Permission> Permissions { get; set; } = new List<Permission>();
    }
}
