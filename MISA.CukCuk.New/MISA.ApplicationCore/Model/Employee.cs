using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Model
{
   
    /// <summary>
    /// Class Nhân viên
    /// </summary>
    /// CreatedBy: ABC(22/01/2021)
    public class Employee
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
        public Guid EmployeeId { get; set; }
        /// <summary>
        /// Mã khách hàng
        /// </summary>
        [CheckDuplicate()]
        [Required()]
        [DisplayName("Mã nhân viên")]
        //Đánh dấu check trùng
        public string EmployeeCode { get; set; }
        /// <summary>
        /// Họ tên
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime? DateOfBirth { get; set; }
        /// <summary>
        /// Giới tính (0. nam, 1. nữ, 2. khác)
        /// </summary>
        public int? Gender { get; set; } //Cho phép trống có dạng: public(protected) định dạng? Name{get; set}
       /// <summary>
       /// Số chứng minh nhân dân
       /// </summary>
        public string CitizenID { get; set; }
        /// <summary>
        /// Ngày cấp
        /// </summary>
        public DateTime DateOfID { get; set; }
        /// <summary>
        /// Nơi cấp
        /// </summary>
        public string PlaceOfID { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; } // string là chuỗi đặc biệt nên tự có định dạng trống ko cần thêm '?'
        /// <summary>
        /// Số điện thoại
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Vị trí làm việc
        /// </summary>
        public string PositionName { get; set; }
        /// <summary>
        /// id chức vụ
        /// </summary>
        public Guid? PositionId { get; set; }
        /// <summary>
        /// Vị trí phòng ban
        /// </summary>
        public string DepartmentName { get; set; }
        /// <summary>
        /// id vị trí phòng ban
        /// </summary>
        public Guid? DepartmentId { get; set; }
        /// <summary>
        /// Mã số thuế cá nhân
        /// </summary>
        public string PersonalTaxCode { get; set; }
        /// <summary>
        /// Mức lương cơ bản
        /// </summary>
        public double  Salary { get; set; }
        /// <summary>
        /// Ngày ra nhập công ty
        /// </summary>
        public DateTime? DateOfJoining { get; set; }
        /// <summary>
        /// Tình trạng công việc
        /// </summary>
        public int WorkStatus { get; set; }
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

