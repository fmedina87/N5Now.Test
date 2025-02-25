using Microsoft.EntityFrameworkCore;
using N5Now.Test.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5Now.Test.Infrastructure.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<PermissionType> PermissionTypes { get; set; }
        public DbSet<Permission> Permissions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Permissions)
                .WithOne(p => p.Employee)
                .HasForeignKey(p => p.EmployeeId);

            modelBuilder.Entity<PermissionType>()
                .HasMany(pt => pt.Permissions)
                .WithOne(p => p.PermissionType)
                .HasForeignKey(p => p.PermissionTypeId);
        }
    }
}
