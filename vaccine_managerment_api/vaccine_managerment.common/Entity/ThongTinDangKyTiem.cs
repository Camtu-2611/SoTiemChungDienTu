using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vaccine_managerment.common
{
    public class ThongTinDangKyTiem: BaseEntity
    {
        /// <summary>
        /// khóa chính
        /// </summary>
        [Key]
        public Guid iddangky { get; set; }

        public string hoten { get; set; }
        public DateTime ngaysinh { get; set; }

        public string gioitinh { get; set; }

        /// <summary>
        /// bắt buộc nhập vì là trường để get dữ liệu về sau
        /// </summary>
        public string sodienthoai { get; set; }

        public string email { get; set; }

        public string diachi { get; set; }

        public string tentrungtam { get; set; }
        public Guid idtrungtam { get; set; }
        public DateTime ngaydangkytiem { get; set; }
        /// <summary>
        /// danh sách vacxin đăng ký tiêm - tạm thời lưu dạng string --> split để lấy thông tin
        /// </summary>
        public string danhsachvacxin { get; set; }
    }
}
