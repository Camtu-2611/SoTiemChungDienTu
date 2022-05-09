using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vaccine_managerment.common;
using vaccine_managerment.infrastructure;

namespace vaccine_managerment.core
{
    public class TrungTamTiemChungBL:BaseBL<TrungTamTiemChung>, ITrungTamTiemChungBL
    {
        private ITrungTamTiemChungDL _trungtamtiemchungDL;
        public TrungTamTiemChungBL(ITrungTamTiemChungDL trungtamtiemchungDL) : base(trungtamtiemchungDL)
        {
            _trungtamtiemchungDL = trungtamtiemchungDL;
        }
    }
}
