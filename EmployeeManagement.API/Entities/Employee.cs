using EmployeeManagement.API.Enums;

namespace EmployeeManagement.API.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }
       
        public string? Code { get; set; }

        public string? Fullname { get; set; }

        public Gender Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

        public Guid JobPositionId { get; set; }

        public Guid DepartmentId { get; set; }

        public Decimal Salary { get; set; }

        public WorkStatus WorkStatus { get; set; }

        public string? IdentityNumber { get; set; }
        public DateTime IdentityIssuerDate { get; set; }

        public string? IdentityIssuerPlace { get; set; }

        public string? TaxCode { get; set; }
       
        public DateTime JoiningDate { get; set; }

       


    }
}
