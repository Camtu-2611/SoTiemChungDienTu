using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vaccine_managerment.common
{
    /// <summary>
    /// Lớp lưu trữ thông tin chung của các thực thể
    /// CreatedBy: nctu(29.04.2022)
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// Ngày tạo thực thể
        /// </summary>
        public DateTime? ngaytao { get; set; }

        /// <summary>
        /// Người tạo thực thể
        /// </summary>
        public string nguoitao { get; set; }

        /// <summary>
        /// Ngày chỉnh sửa thực thể
        /// </summary>
        public DateTime? ngaychinhsua { get; set; }

        /// <summary>
        /// Người chỉnh sửa đối tượng
        /// </summary>
        public string nguoichinhsua { get; set; }
    }
}
