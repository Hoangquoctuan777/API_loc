using EmployeeManagement.API.Entities;
using EmployeeManagement.API.Entities.DTO;
using EmployeeManagement.API.Enums;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.API.Controllers
{
    /// <summary>
    /// Các API liên quan đến nhân viên
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        /// <summary>
        /// API lấy danh sách nhân viên theo điều kiện lọc và phân trang
        /// </summary>
        /// <param name="keyword">Từ khóa muốn tìm kiếm: Mã nhân viên(Code), tên nhân viên(Fullname), số điện thoại(PhoneNumber) </param>
        /// <param name="jobPositionId">Id vị trí</param>
        /// <param name="departmentId">Id phòng ban</param>
        /// <param name="limit">Bản ghi muốn lấy </param>
        /// <param name="offset">Vị trí bản ghi bắt đầu lấy</param>
        /// <returns>
        /// Trả về đối tượng PagingResult,và danh sách sinh viên trên một trang & tổng số bản ghi thỏa mãn điều kiện
        /// </returns>
        [HttpGet]
        public PagingResult GetPaging(
            [FromQuery] string keyword,
            [FromQuery] Guid jobPositionId,
            [FromQuery] Guid departmentId,
            [FromQuery] int limit,
            [FromQuery] int offset)
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
                        Salary = 3440,
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
                        IdentityIssuerPlace = "Ba vì",
                        TaxCode = "5555",
                        JoiningDate = new DateTime(2019,3,12),
                    }

                },
                TotalRecords = 3


            };
        }
    }
}
