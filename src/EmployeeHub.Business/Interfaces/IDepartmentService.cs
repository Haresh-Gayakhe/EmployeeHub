using EmployeeHub.Entities.DTOs.Department;

namespace EmployeeHub.Business.Interfaces
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentResponseDto>> GetAllAsync();
        Task<DepartmentResponseDto?> GetByIdAsync(Guid id);
        Task CreateAsync(CreateDepartmentDto dto);
        Task UpdateAsync(Guid id, UpdateDepartmentDto dto);
        Task DeleteAsync(Guid id);
    }
}
