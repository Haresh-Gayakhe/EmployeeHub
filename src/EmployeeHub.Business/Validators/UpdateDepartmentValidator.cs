using EmployeeHub.Entities.DTOs.Department;
using FluentValidation;

namespace EmployeeHub.Business.Validators
{
    public class UpdateDepartmentValidator : AbstractValidator<UpdateDepartmentDto>
    {
        public UpdateDepartmentValidator()
        {
            RuleFor(x => x.DepartmentName).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Description).MaximumLength(500);
        }
    }
}
