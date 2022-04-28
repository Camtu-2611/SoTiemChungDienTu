using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vaccine_managerment.common
{
    public class LichTiem:BaseEntity
    {
        /// <summary>
        /// khóa chính
        /// </summary>
        [Key]
        public Guid idlichtiem { get; set; }

        /// <summary>
        /// mã sổ tiêm của người đăng ký
        /// </summary>
        public string masotiem { get; set; }

        public string tennguoihen { get; set; }

        public string sodienthoai { get; set; }

        public string email { get; set; }

        public string mavacxin { get; set; }

        public string tenvacxin { get; set; }

        public DateTime ngayhentiem { get; set; }

        public string noihentiem { get; set; }

        public Guid idtrungtam { get; set; }

        public Guid idsotiem { get; set; }

        public Guid idvacxin { get; set; }
    }
}
