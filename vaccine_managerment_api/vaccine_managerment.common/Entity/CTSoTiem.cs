using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vaccine_managerment.common
{
    public class CTSoTiem:BaseEntity
    {
        /// <summary>
        /// khóa chính - tự động tạo
        /// </summary>
        [Key]
        public Guid idctsotiem { get; set; }

        /// <summary>
        /// mã sổ tiêm
        /// </summary>
        public string masotiem { get; set; }

        /// <summary>
        /// họ tên người tiêm
        /// </summary>
        public string hoten { get; set; }

        /// <summary>
        /// mã vắc xin
        /// </summary>
        public string mavacxin { get; set; }

        /// <summary>
        /// tên sổ tiêm
        /// </summary>
        public string tenvacxin { get; set; }

        /// <summary>
        /// lần tiêm
        /// </summary>
        public int lantiem { get; set; }

        
        /// <summary>
        /// ngày tiêm
        /// </summary>
        public DateTime? ngaytiem { get; set; }
        
        /// <summary>
        /// phản ứng sau tiêm
        /// </summary>
        public string phanungsautiem { get; set; }

        /// <summary>
        /// ngày hẹn tiêm lần sau (nếu có)
        /// </summary>
        public DateTime? ngayhen { get; set; }

        /// <summary>
        /// nơi tiêm
        /// </summary>
        public string noitiem { get; set; }

        /// <summary>
        /// mã nhân viên thực hiện tiêm
        /// </summary>
        public string manhanvien { get; set; }

    }
}
