using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vaccine_managerment.common
{
    public class GoiVacxin: BaseEntity
    {
        /// <summary>
        /// id vacxin
        /// </summary>
        [Key]
        public Guid idgoivacxin { get; set; }

        /// <summary>
        /// mã vắc xin
        /// </summary>
        public string tengoi { get; set; }
        /// <summary>
        /// tên vắc xin
        /// </summary>
        public string magoivacxin { get; set; }

        /// <summary>
        /// ngày nhập vắc xin
        /// </summary>
        public DateTime ngaytao { get; set; }
        /// <summary>
        /// ngày nhập vắc xin
        /// </summary>
        public DateTime ngaychinhsua { get; set; }

        /// <summary>
        /// mô tả về gói vắc xin
        /// </summary>
        public string mota { get; set; }

        /// <summary>
        /// mô tả về người tạo
        /// </summary>
        public string nguoitao { get; set; }


        /// <summary>
        /// mô tả về người chỉnh sửa
        /// </summary>
        public string nguoichinhsua { get; set; }
        /// <summary>
        /// giá vắc xin
        /// </summary>
        public long dongia { get; set; }
    }
}
