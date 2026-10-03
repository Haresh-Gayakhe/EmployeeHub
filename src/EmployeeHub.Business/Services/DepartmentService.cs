using EmployeeHub.Business.Interfaces;
using EmployeeHub.DataAccess.Repositories.Interfaces;
using EmployeeHub.Entities.DTOs.Department;
using EmployeeHub.Entities.Models;

namespace EmployeeHub.Business.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _repository;
        public DepartmentService(IDepartmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<DepartmentResponseDto>> GetAllAsync()
        {
            var departments = await _repository.GetAllAsync();

            return departments.Select(d =>
                new DepartmentResponseDto
                {
                    Id = d.Id,
                    DepartmentName = d.DepartmentName,
                    Description = d.Description,
                });
        }

        public async Task<DepartmentResponseDto?> GetByIdAsync(Guid id)
        {
            var department = await _repository.GetByIdAsync(id);

            if(department == null)
                return null;

            return new DepartmentResponseDto
            {
                Id = department.Id,
                DepartmentName = department.DepartmentName,
                Description = department.Description,
            };
        }

        public async Task CreateAsync(CreateDepartmentDto dto)
        {
            var department = new Department
            {
                Id = Guid.NewGuid(),
                DepartmentName = dto.DepartmentName,
                Description = dto.Description,
                CreatedDate = DateTime.UtcNow
            };

            await _repository.AddAsync(department);
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(Guid id, UpdateDepartmentDto dto)
        {
            var department = await _repository.GetByIdAsync(id);

            if (department == null)
                throw new Exception("Department not found");

            department.DepartmentName = dto.DepartmentName;
            department.Description = dto.Description;
            department.ModifiedDate = DateTime.UtcNow;

            _repository.Update(department);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var department = await _repository.GetByIdAsync(id);

            if (department == null)
                throw new Exception("Department not found");

            _repository.Delete(department);
            await _repository.SaveChangesAsync();
        }
    }
}
