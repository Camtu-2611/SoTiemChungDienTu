using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vaccine_managerment.common;
using vaccine_managerment.infrastructure;

namespace vaccine_managerment.core
{
    public class VacxinBL:BaseBL<Vacxin>, IVacxinBL
    {
        private IVacxinDL _vacxinDL;
        public VacxinBL(IVacxinDL vacxinDL) : base(vacxinDL)
        {
            _vacxinDL = vacxinDL;
        }
    }
}
