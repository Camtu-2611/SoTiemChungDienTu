using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vaccine_managerment.common;
using vaccine_managerment.infrastructure;

namespace vaccine_managerment.core
{
    public class SoTiemBL: BaseBL<SoTiem>, ISoTiemBL
    {
        private ISoTiemDL _sotiemDL;
        public SoTiemBL(ISoTiemDL sotiemDL) : base(sotiemDL)
        {
            _sotiemDL = sotiemDL;
        }
    }
}
