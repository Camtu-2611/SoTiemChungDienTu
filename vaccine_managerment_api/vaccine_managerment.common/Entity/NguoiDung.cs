using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vaccine_managerment.common
{
    public class NguoiDung
    {
        /// <summary>
        /// id người dùng - khóa chính
        /// </summary>
        [Key]
        public Guid idnguoidung { get; set; }

        /// <summary>
        /// mã người dùng
        /// </summary>
        public string manguoidung { get; set; }

        /// <summary>
        /// tên nhóm người dùng
        /// </summary>
        public string tennguoidung { get; set; }

        public string matkhau { get; set; }

        public string manhomnd { get; set; }

        public string maquyen { get; set; }

        public Guid idnhomnd { get; set; }
    }
}
