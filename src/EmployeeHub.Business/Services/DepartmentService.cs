using AutoMapper;
using EmployeeHub.Business.Interfaces;
using EmployeeHub.DataAccess.Repositories.Interfaces;
using EmployeeHub.Entities.DTOs.Department;
using EmployeeHub.Entities.Models;

namespace EmployeeHub.Business.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _repository;
        private readonly IMapper _mapper;
        public DepartmentService(IDepartmentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DepartmentResponseDto>> GetAllAsync()
        {
            var departments = await _repository.GetAllAsync();

            return _mapper.Map<IEnumerable<DepartmentResponseDto>>(departments);
        }

        public async Task<DepartmentResponseDto?> GetByIdAsync(Guid id)
        {
            var department = await _repository.GetByIdAsync(id);

            if(department == null)
                return null;

            return _mapper.Map<DepartmentResponseDto>(department);
        }

        public async Task CreateAsync(CreateDepartmentDto dto)
        {
            var department = _mapper.Map<Department>(dto);

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
            //department.ModifiedDate = DateTime.UtcNow;

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
