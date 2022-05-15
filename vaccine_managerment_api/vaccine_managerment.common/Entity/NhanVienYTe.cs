using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vaccine_managerment.common
{
    public class NhanVienYTe: BaseEntity
    {
        /// <summary>
        /// id nhân viên
        /// Khóa chính
        /// </summary>
        [Key]
        public Guid idnhanviennhanvienyte { get; set; }

        /// <summary>
        /// mã nhân viên
        /// không được trùng
        /// </summary>
        public string manhanvien { get; set; }


        /// <summary>
        /// tên nhân viên
        /// </summary>
        public string tennhanvien { get; set; }


        /// <summary>
        /// ngày tháng năm sinh
        /// </summary>
        public DateTime ngaysinh { get; set; }


        /// <summary>
        /// giới tính
        /// </summary>
        public string gioitinh { get; set; }


        /// <summary>
        /// chức vụ
        /// </summary>
        public string chucvu { get; set; }

        /// <summary>
        /// bộ phận làm việc
        /// </summary>
        public string bophanlamviec { get; set; }

        /// <summary>
        /// số điện thoại
        /// </summary>
        public string sodienthoai { get; set; }
    }
}
