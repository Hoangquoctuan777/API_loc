using EmployeeManagement.API.Entities;
using EmployeeManagement.API.Entities.DTO;
using EmployeeManagement.API.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace EmployeeManagement.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        [HttpGet]
        public PagingResult GetPaging(
            [FromQuery] string? keyword,
            [FromQuery] Guid JobPositionId,
            [FromQuery] Guid DepartmentId,
            [FromQuery] int Limit,
            [FromQuery] int Offset)
        {
            return new PagingResult
            {
                Data = new List<Employee>
                {
                    new Employee
                    {
                        Id = Guid.NewGuid(),
                        Code = "NV001",
                        Fullname = "Nguyên Văn A",
                        Gender = Gender.Male,
                        DateOfBirth = new DateTime(2003,1,2),
                        PhoneNumber = "99999999",
                        Email = "hoangtuan@gmail.com",
                        JobPositionId = Guid.NewGuid(),
                        DepartmentId = Guid.NewGuid(),
                        Salary = 0,
                        WorkStatus = WorkStatus.TrialJob,
                        IdentityNumber = "88888888",
                        IdentityIssuerDate = new DateTime(2016,3,12),
                        IdentityIssuerPlace = "Lào Cai",
                        TaxCode = "5555",
                        JoiningDate = new DateTime(2019,3,12),

                    },

                    new Employee
                    {
                        Id = Guid.NewGuid(),
                        Code = "NV002",
                        Fullname = "Phạm Tuấn Duy",
                        Gender = Gender.Female,
                        DateOfBirth = new DateTime(2003,3,12),
                        PhoneNumber = "99999999",
                        Email = "hoangtuan@gmail.com",
                        JobPositionId = Guid.NewGuid(),
                        DepartmentId = Guid.NewGuid(),
                        Salary = 0,
                        WorkStatus = WorkStatus.TrialJob,
                        IdentityNumber = "88888888",
                        IdentityIssuerDate = new DateTime(2017,3,12),
                        IdentityIssuerPlace = "Lào Cai",
                        TaxCode = "5555",
                        JoiningDate = new DateTime(2019,3,12),

                    },

                    new Employee
                    {
                        Id = Guid.NewGuid(),
                        Code = "NV003",
                        Fullname = "Phùng Văn Đức",
                        Gender = Gender.Male,
                        DateOfBirth =  new DateTime(2002,3,12),
                        PhoneNumber = "99999999",
                        Email = "hoangtuan@gmail.com",
                        JobPositionId = Guid.NewGuid(),
                        DepartmentId = Guid.NewGuid(),
                        Salary = 0,
                        WorkStatus = WorkStatus.TrialJob,
                        IdentityNumber = "88888888",
                        IdentityIssuerDate = new DateTime(2016,3,12),
                        IdentityIssuerPlace = "Lào Cai",
                        TaxCode = "5555",
                        JoiningDate = new DateTime(2019,3,12),
                    }

                },
                TotalRecords = 3


            };
            if (!string.IsNullOrEmpty(keyword))
            {
                employees = employees.Where(e => e.Code.Contains(keyword) || e.Fullname.Contains(keyword)).ToList();
            }
            return new PagingResult();
            
        }
    }
}
