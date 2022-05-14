using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vaccine_managerment.common;

namespace vaccine_managerment.infrastructure
{
    public interface ISoTiemDL:IBaseDL<SoTiem>
    {
        /// <summary>
        /// Lấy thông tin sổ tiêm theo mã sổ tiêm
        /// </summary>
        /// <param name="masotiem">mã sổ tiêm</param>
        /// <returns></returns>
        /// CreatedBy: nctu 1.05.2022
        public SoTiem GetSoTiemByCode(string masotiem);
    }
}
