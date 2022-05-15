using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vaccine_managerment.common
{
    public class LoaiVacxin: BaseEntity
    {
        /// <summary>
        /// id loại vắc xin
        /// </summary>
        [Key]
        public Guid idloaivacxin { get; set; }

        /// <summary>
        /// mã loại vắc xin
        /// </summary>
        public string maloai { get; set; }

        /// <summary>
        /// tên loại vắc xin
        /// </summary>
        public string tenloai { get; set; }

        /// <summary>
        /// tuổi áp dụng
        /// </summary>
        public int tuoiapdung { get; set; }

        /// <summary>
        /// giới tính áp dụng
        /// </summary>
        public string gioitinhapdung { get; set; }
    }
}
