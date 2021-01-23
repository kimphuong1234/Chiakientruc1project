using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Model
{
    public class ServiceResult
    {
        /// <summary>
        /// Trạng thái xử lý nghiệp vụ ( false - dữ liệu không hợp lệ, true - thành công)
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// Dữ liệu muốn trả về cho Client
        /// </summary>
        public object Data { get; set; }
        /// <summary>
        /// Thông báo trả về
        /// </summary>
        public object Messenger { get; set; }
    }
}
