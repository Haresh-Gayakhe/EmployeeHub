namespace EmployeeHub.Entities.DTOs.Department
{
    public class CreateDepartmentDto
    {
        public string DepartmentName { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
