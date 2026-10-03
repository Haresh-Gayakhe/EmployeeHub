using EmployeeHub.DataAccess.Context;
using EmployeeHub.DataAccess.Repositories.Interfaces;
using EmployeeHub.Entities.Models;

namespace EmployeeHub.DataAccess.Repositories
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(ApplicationDbContext context) : base(context)
        {
            
        }
    }
}
