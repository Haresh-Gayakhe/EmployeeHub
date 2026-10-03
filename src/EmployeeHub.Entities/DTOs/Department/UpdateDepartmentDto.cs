namespace EmployeeHub.Entities.DTOs.Department
{
    public class UpdateDepartmentDto
    {
        public string DepartmentName { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
