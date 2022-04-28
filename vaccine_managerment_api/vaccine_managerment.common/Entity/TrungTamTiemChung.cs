using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vaccine_managerment.common
{
    public class TrungTamTiemChung:BaseEntity
    {
        /// <summary>
        /// khóa chính
        /// </summary>
        [Key]
        public Guid idtrungtam { get; set; }

        /// <summary>
        /// mã trung tâm - duy nhất
        /// </summary>
        public string matrungtam { get; set; }

        /// <summary>
        /// tên trung tâm
        /// </summary>
        public string tentrungtam { get; set; }

        /// <summary>
        /// địa chỉ
        /// </summary>
        public string diachi { get; set; }

        /// <summary>
        /// số điện thoại
        /// </summary>
        public string sodienthoai { get; set; }
    }
}
