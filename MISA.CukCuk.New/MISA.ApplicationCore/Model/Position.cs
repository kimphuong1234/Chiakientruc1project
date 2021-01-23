using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Common.Model
{
    
    /// <summary>
    /// Class Vị trí
    /// </summary>
    /// CreatedBy: ABC(22/01/2021)
    public class Position
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
        public Guid PositionId { get; set; }
        /// <summary>
        /// Tên vị trí
        /// </summary>
        public string PositionName { get; set; }
        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTime? CreatedDate { get; set; }
        /// <summary>
        /// Tạo bởi
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        /// Ngày sửa
        /// </summary>
        public DateTime? ModifiedDate { get; set; }
        /// <summary>
        /// Sửa bởi
        /// </summary>
        public string ModifiedBy { get; set; }
        #endregion
        //Tất cả các phương thức
        #region Method

        #endregion

    }
}

