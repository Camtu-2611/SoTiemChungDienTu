using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vaccine_managerment.common
{
    public enum ErrorCode
    {
        NONE = 0,
        BADREQUEST=400,
        EXCEPTION=500,
        NOCONTENT=204,
        DUPLICATE=2

    }
}
