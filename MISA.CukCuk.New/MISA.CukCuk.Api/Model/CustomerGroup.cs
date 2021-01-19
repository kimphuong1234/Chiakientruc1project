using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Model
{
    /// <summary>
    /// Class Nhóm Khách hàng
    /// </summary>
    /// CreatedBy: ABC(11/01/2021)
    public class CustomerGroup
    {
        //Khai báo các field ko có set get
        #region Declare

        #endregion
        //Khai báo các hàng khởi tạo
        #region Constructor

        #endregion
        //Nơi chứa tất cả các property của Object
        #region Property 
        /// <summary>
        /// Khóa chính
        /// </summary>
        public Guid CustomerGroupId { get; set; }
        /// <summary>
        /// Mã khách hàng
        /// </summary>
        public string CustomerGroupName { get; set; }
        /// <summary>
        /// Họ tên
        /// </summary>
        public string Description { get; set; }
        #endregion
        //Tất cả các phương thức
        #region Method

        #endregion

    }
}
