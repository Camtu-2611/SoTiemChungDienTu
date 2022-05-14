using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vaccine_managerment.common
{
    public class Vacxin: BaseEntity
    {
        /// <summary>
        /// id vacxin
        /// </summary>
        [Key]
        public Guid idvacxin { get; set; }

        /// <summary>
        /// mã vắc xin
        /// </summary>
        public string tenvacxin { get; set; }
        /// <summary>
        /// tên vắc xin
        /// </summary>
        public string mavacxin { get; set; }

        /// <summary>
        /// số lô vắc xin
        /// </summary>
        public string solo { get; set; }

        /// <summary>
        /// ngày nhập vắc xin
        /// </summary>
        public DateTime ngaynhap { get; set; }

        /// <summary>
        /// ngay sản xuất
        /// </summary>
        public DateTime ngaysanxuat { get; set; }

        /// <summary>
        /// hạn sử dụng
        /// </summary>
        public DateTime hansudung { get; set; }

        /// <summary>
        /// mô tả về vắc xin
        /// </summary>
        public string mota { get; set; }

        /// <summary>
        /// lưu thông tin mã loại vắc xin
        /// </summary>
        public string maloai { get; set; }
        /// <summary>
        /// giá vắc xin
        /// </summary>
        public long giavacxin { get; set; }

        /// <summary>
        /// số lượng còn
        /// </summary>
        public int soluong { get; set; }

        /// <summary>
        /// trạng thái vắc xin: 0 - hết hàng, 1 - còn hàng, 2 - sắp hết
        /// </summary>
        public int trangthai { get; set; }
    }
}
