using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vaccine_managerment.common;
using vaccine_managerment.infrastructure;

namespace vaccine_managerment.core
{
    public class NhanVienYTeBL:BaseBL<NhanVienYTe>, INhanVienYTeBL
    {
        private INhanVienYTeDL _nhanvienyteDL;
        public NhanVienYTeBL(INhanVienYTeDL nhanvienyteDL) : base(nhanvienyteDL)
        {
            _nhanvienyteDL = nhanvienyteDL;
        }
    }
}
