using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vaccine_managerment.common
{
    public class Quyen:BaseEntity
    {
        /// <summary>
        /// khóa chính
        /// </summary>
        [Key]
        public Guid idquyen { get; set; }

        /// <summary>
        /// mã quyền
        /// </summary>
        public string maquyen { get; set; }

        /// <summary>
        /// tên quyền
        /// </summary>
        public string tenquyen { get; set; }

        /// <summary>
        /// mô tả
        /// </summary>
        public string mota { get; set; }
    }
}
