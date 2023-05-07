using Dapper;
using EmployeeManagement.API.Entities;
using EmployeeManagement.API.Entities.DTO;
using EmployeeManagement.API.Enums;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Reflection.Metadata;

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
        /// <param name="limit">Số bản ghi muốn lấy </param>
        /// <param name="offset">Vị trí bản ghi bắt đầu lấy</param>
        /// <returns>
        /// Trả về đối tượng PagingResult,và danh sách sinh viên trên một trang & tổng số bản ghi thỏa mãn điều kiện
        /// </returns>
        [HttpGet]
        public IActionResult GetPaging(
            [FromQuery] string? keyword,
            [FromQuery] Guid jobPositionId,
            [FromQuery] Guid departmentId,
            [FromQuery] int limit = 10,
            [FromQuery] int offset = 0)
        {
            return Ok( new PagingResult
            {
                Data = new List<object>
                {
                    new Employee
                    {
                        Id = Guid.NewGuid(),
                        Code = "NV001",
                        FullName = "Nguyên Văn A",
                        Gender = Gender.Male,
                        DateOfBirth = new DateTime(2003,1,2),
                        PhoneNumber = "99999999",
                        Email = "nguyenvana@gmail.com",
                        JobPositionId = Guid.NewGuid(),
                        DepartmentId = Guid.NewGuid(),
                        Salary = 3440,
                        WorkStatus = WorkStatus.TrialJob,
                        IdentityNumber = "88888888",
                        IdentityIssuerDate = new DateTime(2016,3,12),
                        IdentityIssuerPlace = "Hà Nội",
                        TaxCode = "5555",
                        JoiningDate = new DateTime(2019,3,12),

                    },

                    new Employee
                    {
                        Id = Guid.NewGuid(),
                        Code = "NV002",
                        FullName = "Phạm Tuấn Duy",
                        Gender = Gender.Female,
                        DateOfBirth = new DateTime(2003,3,12),
                        PhoneNumber = "99999999",
                        Email = "tuanduy@gmail.com",
                        JobPositionId = Guid.NewGuid(),
                        DepartmentId = Guid.NewGuid(),
                        Salary = 0,
                        WorkStatus = WorkStatus.TrialJob,
                        IdentityNumber = "88888888",
                        IdentityIssuerDate = new DateTime(2017,3,12),
                        IdentityIssuerPlace = "Thái Bình",
                        TaxCode = "5555",
                        JoiningDate = new DateTime(2019,3,12),

                    },

                    new Employee
                    {
                        Id = Guid.NewGuid(),
                        Code = "NV003",
                        FullName = "Phùng Văn Đức",
                        Gender = Gender.Male,
                        DateOfBirth =  new DateTime(2002,3,12),
                        PhoneNumber = "99999999",
                        Email = "vanduc@gmail.com",
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


            });
        }

        /// <summary>
        /// API lấy chi tiết một nhân viên
        /// </summary>
        /// <param name="employeeId">Id nhân viên muốn lấy</param>
        /// <returns>Chi tiết đối tượng nhân viên muốn lấy</returns>
        [HttpGet("{employeeId}")]
        public IActionResult GetEmployeeById([FromRoute] Guid employeeId)
        {
            try
            {
                //Chuẩn bị tên stored procedure
                string storedProcedureName = "Proc_Employee_GetById";

                //Chuẩn bị tham số đầu vào cho stored
                var parameters = new DynamicParameters();
                parameters.Add("p_Id", employeeId);

                //Khởi tạo kết nối tới Database	
                string connectionString = "Server=localhost;Port=3306;Database=employeemanagement;Uid=root;Pwd=admin;";
                var mySqlConnection = new MySqlConnection(connectionString);

                //Thực hiện gọi vào Database để chạy stored procedure
                var employee = mySqlConnection.QueryFirstOrDefault<Employee>(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);

                //Xử lý kết quả trả về 
                if (employee == null)
                {
                    //Nếu không tìm thấy trả về lỗi 404
                    return NotFound();
                }
                else
                {
                    //Thành công trả về 200
                    return Ok(employee);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    ErrorCode = 1,
                    DevMsg = "Catched an exception",
                    UseMsg = "Có lỗi xảy ra vui lòng liên hệ trung tâm tư vấn",
                    MoreInfo = "https://google.com",
                    TraceId = HttpContext.TraceIdentifier
                });
            }
        

        }

        /// <summary>
        /// API lấy mã nhân viên mới tự động tăng
        /// </summary>
        /// <returns>Mã nhân viên mới tự động tăng</returns>
        [HttpGet("new-code")]
        public IActionResult GetNewEmployeeCode()
        {
            return Ok("NV99999");
        }

        /// <summary>
        /// API thêm mới nhân viên 
        /// </summary>
        /// <param name="newEmployee"> Đối tượng nhân viên muốn thêm mới </param>
        /// <returns> Id của một nhân viên mới thêm thành công </returns>
        [HttpPost]  
        public  IActionResult InsertEmployee([FromBody]Employee newEmployee )
        {
            return StatusCode(StatusCodes.Status201Created, Guid.NewGuid());
        }
        
        /// <summary>
        /// API sửa nhân viên
        /// </summary>
        /// <param name="updateEmployee">Đối tượng nhân viên muốn sửa </param>
        /// <param name="employeeId">Id của nhân viên đang muốn sửa</param>
        /// <returns>Id của nhân viên vừa mới sửa</returns>
        [HttpPut("{employeeId}")]    
        public IActionResult UpdateEmployee([FromBody]Employee updateEmployee, [FromRoute] Guid employeeId)
        {
            try
            {
                // Chuẩn bị tên stored procedure
                string storedProcedureName = "Proc_Employee_Update";

                // Chuẩn bị tham số đầu vào cho stored procedure
                var parameters = new DynamicParameters();
                parameters.Add("p_Id", employeeId);
                //parameters.Add("p_Code", updateEmployee.Code);
                //parameters.Add("p_FullName", updateEmployee.FullName);
                //parameters.Add("p_Gender", updateEmployee.Gender);
                //parameters.Add("p_DateOfBirth", updateEmployee.DateOfBirth);
                //parameters.Add("p_PhoneNumber", updateEmployee.PhoneNumber);
                //parameters.Add("p_Email", updateEmployee.Email);
                //parameters.Add("p_JobPositionId", updateEmployee.JobPositionId);
                //parameters.Add("p_DepartmentId", updateEmployee.DepartmentId);
                //parameters.Add("p_Salary", updateEmployee.Salary);
                //parameters.Add("p_WorkStatus", updateEmployee.WorkStatus);
                //parameters.Add("p_IdentityNumber", updateEmployee.IdentityNumber);
                //parameters.Add("p_IdentityIssuerDate", updateEmployee.IdentityIssuerDate);
                //parameters.Add("p_IdentityIssuerPlace", updateEmployee.IdentityIssuerPlace);
                //parameters.Add("p_TaxCode", updateEmployee.TaxCode);
                //parameters.Add("p_JoiningDate", updateEmployee.JoiningDate);

                // Thêm các tham số khác tùy thuộc vào thông tin cần cập nhật

                // Khởi tạo kết nối tới Database	
                string connectionString = "Server=localhost;Port=3306;Database=employeemanagement;Uid=root;Pwd=admin;";
                var mySqlConnection = new MySqlConnection(connectionString);

                // Thực hiện gọi vào Database để chạy stored procedure
               var employee = mySqlConnection.Execute(storedProcedureName, parameters, commandType: CommandType.StoredProcedure);

                return Ok(employee); // Trả về phản hồi HTTP 204 No Content nếu sửa thành công
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    ErrorCode = 1,
                    DevMsg = "Catched an exception",
                    UseMsg = "Có lỗi xảy ra, vui lòng liên hệ trung tâm tư vấn",
                    MoreInfo = "https://google.com",
                    TraceId = HttpContext.TraceIdentifier
                });
            }
        }

        /// <summary>
        /// API Xóa nhân viên
        /// </summary>
        /// <param name="employeeId">Id của nhân viên muốn xóa</param>
        /// <returns>Id của nhân viên vừa xóa</returns>
        [HttpDelete("{employeeId}")]
        public IActionResult DeleteEmployee([FromRoute] Guid employeeId)
        {
            try
            {
                //Chuẩn bị tên stored procedure
                string storedProcedureName = "Proc_employee_Delete";

                //Chuẩn bị tham số đầu vào cho stored
                var parameters = new DynamicParameters();
                parameters.Add("p_Id", employeeId);

                //Khởi tạo kết nối tới Database	
                string connectionString = "Server=localhost;Port=3306;Database=employeemanagement;Uid=root;Pwd=admin;";
                var mySqlConnection = new MySqlConnection(connectionString);

                //Thực hiện gọi vào Database để chạy stored procedure
                var employee = mySqlConnection.Execute(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);

                //Xử lý kết quả trả về 
                if (employee == 0)
                {
                    return NotFound(); // Trả về phản hồi HTTP 404 Not Found nếu không tìm thấy nhân viên
                }

                return Ok(employeeId); // Trả về phản hồi HTTP 200 và id vừa xóa nếu xóa thành công

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    ErrorCode = 1,
                    DevMsg = "Catched an exception",
                    UseMsg = "Có lỗi xảy ra vui lòng liên hệ trung tâm tư vấn",
                    MoreInfo = "https://google.com",
                    TraceId = HttpContext.TraceIdentifier
                });
            }

        }



    }
}
