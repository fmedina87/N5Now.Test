﻿using N5Now.Test.Domain.Entities;
using N5Now.Test.Domain.Interfaces.Repositories;
using N5Now.Test.Infrastructure.Data;

namespace N5Now.Test.Infrastructure.Repositories
{
    public class EmployeeRepository(ApplicationDbContext context) : BasicQuerysRepository<Employee>(context), IEmployeeRepository
    {
    }
}
