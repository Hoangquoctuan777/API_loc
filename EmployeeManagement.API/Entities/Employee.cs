using EmployeeManagement.API.Enums;

namespace EmployeeManagement.API.Entities
{
    /// <summary>
    /// Khai báo các thuộc tính nhân viên
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Id nhân viên
        /// </summary>
        public Guid Id { get; set; }
       /// <summary>
       /// Mã nhân viên
       /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Tên nhân viên
        /// </summary>
        public string? Fullname { get; set; }
        /// <summary>
        /// Giới tính
        /// </summary>
        public Gender Gender { get; set; }
        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime DateOfBirth { get; set; }
        /// <summary>
        /// Số điện thoại
        /// </summary>
        public string? PhoneNumber { get; set; }
        /// <summary>
        /// Thư điện tử
        /// </summary>
        public string? Email { get; set; }
        /// <summary>
        /// Vị trí, chức vụ
        /// </summary>
        public Guid JobPositionId { get; set; }
        /// <summary>
        /// Phòng ban
        /// </summary>
        public Guid DepartmentId { get; set; }
        /// <summary>
        /// Lương
        /// </summary>
        public Decimal Salary { get; set; }
        /// <summary>
        /// Trạng thái làm việc
        /// </summary>
        public WorkStatus WorkStatus { get; set; }
        /// <summary>
        /// Số CCCD
        /// </summary>
        public string? IdentityNumber { get; set; }
        /// <summary>
        /// Ngày cấp CCCD
        /// </summary>
        public DateTime IdentityIssuerDate { get; set; }
        /// <summary>
        /// Nơi cấp CCCD
        /// </summary>
        public string? IdentityIssuerPlace { get; set; }
        /// <summary>
        /// Mã số thuế
        /// </summary>
        public string? TaxCode { get; set; }
       /// <summary>
       /// Ngày gia nhập công ty
       /// </summary>
        public DateTime JoiningDate { get; set; }

       


    }
}
