using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vaccine_managerment.common
{
    public class NhomNguoiDung
    {
        /// <summary>
        /// id nhóm người dùng - khóa chính
        /// </summary>
        [Key]
        public Guid idnhomnd { get; set; }

        /// <summary>
        /// mã nhóm người dùng
        /// </summary>
        public string manhomnd { get; set; }

        /// <summary>
        /// tên nhóm người dùng
        /// </summary>
        public string tennhomnd { get; set; }
    }
}
