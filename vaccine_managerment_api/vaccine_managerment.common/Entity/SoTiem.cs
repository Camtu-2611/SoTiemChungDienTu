using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vaccine_managerment.common
{
    public class SoTiem:BaseEntity
    {
        public Guid idsotiem { get; set; }

        public string masotiem { get; set; }

        public string hoten { get; set; }
        public DateTime ngaysinh { get; set; }

        public string gioitinh { get; set; }

        public string sodienthoai { get; set; }

        public string cmnd { get; set; }

        public string email { get; set; }

        public string diachi { get; set; }
        public int tuoi { get; set; }
    }
}
