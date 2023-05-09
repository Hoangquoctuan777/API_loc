using EmployeeManagement.API.Enums;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.API.Entities
{
    /// <summary>
    /// Khai báo các thuộc tính nhân viên
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Id nhân viên (Khóa chính)
        /// </summary>  
        public Guid Id { get; set; }
       
        /// <summary>
        /// Mã nhân viên
        /// </summary>
        [Required(ErrorMessage ="Mã nhân viên không được để trống")]
        [MaxLength(20, ErrorMessage ="Mã nhân viên không được vượt quá 20 ký tự")]
        public string Code { get; set; }

        /// <summary>
        /// Tên nhân viên
        /// </summary>
        [Required(ErrorMessage = "Tên nhân viên không được để trống")]
        [MaxLength(100, ErrorMessage = "Tên nhân viên không được vượt quá 100 ký tự")]
        public string FullName { get; set; }
       
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
        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        [MaxLength(25, ErrorMessage = "Số điện thoại không được vượt quá 25 ký tự")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Thư điện tử
        /// </summary>
        [Required(ErrorMessage = "Email không được để trống")]
        [MaxLength(50, ErrorMessage = "Email không được vượt quá 50 ký tự")]
        [EmailAddress(ErrorMessage = "Email không đúng định dạng")]
        public string Email { get; set; }
       
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
        [Required(ErrorMessage = "CCCD không được để trống")]
        [MaxLength(25, ErrorMessage = "CCCD không được vượt quá 25 ký tự")]
        public string IdentityNumber { get; set; }
       
        /// <summary>
        /// Ngày cấp CCCD
        /// </summary>
        public DateTime IdentityIssuerDate { get; set; }
       
        /// <summary>
        /// Nơi cấp CCCD
        /// </summary>
        public string IdentityIssuerPlace { get; set; }
       
        /// <summary>
        /// Mã số thuế
        /// </summary>
        public string TaxCode { get; set; }
       
        /// <summary>
       /// Ngày gia nhập công ty
       /// </summary>
        public DateTime JoiningDate { get; set; }

       


    }
}
