using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vaccine_managerment.common;
using vaccine_managerment.infrastructure;

namespace vaccine_managerment.core
{
    public class CTSoTiemBL : BaseBL<CTSoTiem>, ICTSoTiemBL
    {
        private ICTSoTiemDL _ctsotiemDL;
        public CTSoTiemBL(ICTSoTiemDL ctsotiemDL) : base(ctsotiemDL)
        {
            _ctsotiemDL = ctsotiemDL;
        }
    }
}
