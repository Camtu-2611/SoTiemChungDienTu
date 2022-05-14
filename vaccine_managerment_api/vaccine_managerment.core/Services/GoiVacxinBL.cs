using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vaccine_managerment.common;
using vaccine_managerment.infrastructure;

namespace vaccine_managerment.core
{
    public class GoiVacxinBL:BaseBL<GoiVacxin>, IGoiVacxinBL
    {
        private IGoiVacxinDL _goivacxinDL;
        public GoiVacxinBL(IGoiVacxinDL goivacxinDL) : base(goivacxinDL)
        {
            _goivacxinDL = goivacxinDL;
        }
    }
}
