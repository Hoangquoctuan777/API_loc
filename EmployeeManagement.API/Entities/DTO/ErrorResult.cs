using EmployeeManagement.API.Enums;

namespace EmployeeManagement.API.Entities.DTO
{
    /// <summary>
    /// Khai báo thuộc tính mô tả lỗi
    /// </summary>
    public class ErrorResult
    {
        /// <summary>
        /// Định danh nội bộ
        /// </summary>
        public ErrorCode ErrorCode { get; set; }
        
        /// <summary>
        /// Thông báo cho dev về vấn đề đang gặp phải
        /// </summary>
        public string DevMsg { get; set; }

        /// <summary>
        /// Thông báo cho user về lỗi đang gặp phải
        /// </summary>
        public string UserMsg { get; set; }

        /// <summary>
        /// Thông tin chi tiết hơn về vấn đề
        /// </summary>
        public object MoreInfo { get; set; }

        /// <summary>
        /// Mã để tra cứu thông tin log
        /// </summary>
        public string TraceId { get; set; }
    }
}
