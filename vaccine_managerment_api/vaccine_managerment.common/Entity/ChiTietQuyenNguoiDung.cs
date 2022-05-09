using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vaccine_managerment.common
{
    public class ChiTietQuyenNguoiDung
    {
        public string manguoidung { get; set; }

        public string maquyen { get; set; }

        public string mota { get; set; }

        public Guid idquyen { get; set; }

        public Guid idnguoidung { get; set; }
    }
}
