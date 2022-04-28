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
        /// mã vắc xin
        /// </summary>
        public string mavacxin { get; set; }

        /// <summary>
        /// lần tiêm
        /// </summary>
        public int lantiem { get; set; }

        /// <summary>
        /// ngày hẹn tiêm lần sau (nếu có)
        /// </summary>
        public DateTime ngayhen { get; set; }

        /// <summary>
        /// nơi tiêm
        /// </summary>
        public string noitiem { get; set; }

        /// <summary>
        /// mã nhân viên thực hiện tiêm
        /// </summary>
        public string manhanvien { get; set; }

        /// <summary>
        /// id nhân viên
        /// </summary>
        public Guid idnhanvien { get; set; }

        /// <summary>
        /// id sổ tiêm
        /// </summary>
        public Guid idsotiem { get; set; }

        /// <summary>
        /// id vắc xin
        /// </summary>
        public Guid idvacxin { get; set; }
    }
}
