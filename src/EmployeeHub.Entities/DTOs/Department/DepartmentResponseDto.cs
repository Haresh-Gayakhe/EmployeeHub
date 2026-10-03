namespace EmployeeHub.Entities.DTOs.Department
{
    public class DepartmentResponseDto
    {
        public Guid Id { get; set; }
        public string DepartmentName { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
