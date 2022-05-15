using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vaccine_managerment.common;

namespace vaccine_managerment.core
{
    public interface ICTSoTiemBL:IBaseBL<CTSoTiem>
    {
        /// <summary>
        /// Lấy thông tin CT sổ tiêm theo mã sổ tiêm
        /// </summary>
        /// <param name="masotiem">mã sổ tiêm</param>
        /// <returns></returns>
        /// CreatedBy: nctu 11.05.2022
        public ServiceResult GetCTSoTiemByCode(string masotiem);
    }
}
