using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vaccine_managerment.common;
using vaccine_managerment.infrastructure;

namespace vaccine_managerment.core
{
    public class LoaiVacxinBL:BaseBL<LoaiVacxin>, ILoaiVacxinBL
    {
        private ILoaiVacxinDL _loaivacxinDL;
        public LoaiVacxinBL(ILoaiVacxinDL loaivacxinDL) : base(loaivacxinDL)
        {
            this._loaivacxinDL = loaivacxinDL;
        }
    }
}
