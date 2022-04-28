using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vaccine_managerment.common;
using vaccine_managerment.infrastructure;

namespace vaccine_managerment.core
{
    public class LichTiemBL:BaseBL<LichTiem>, ILichTiemBL
    {
        private ILichTiemDL _lichtiemDL;
        public LichTiemBL(ILichTiemDL lichtiemDL) : base(lichtiemDL)
        {
            _lichtiemDL = lichtiemDL;
        }
    }
}
