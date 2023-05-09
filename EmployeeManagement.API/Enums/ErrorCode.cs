namespace EmployeeManagement.API.Enums
{
    /// <summary>
    /// Định dạng nội bộ ErrorCode
    /// </summary>
    public enum ErrorCode
    {

        /// <summary>
        /// Lỗi Try-Catch
        /// </summary>
        Exception = 1,

        /// <summary>
        /// Lỗi Database
        /// </summary>
        DatabaseFailed = 2,

        /// <summary>
        /// Lỗi FontEnd
        /// </summary>
        InvaledData = 3
    }
}
