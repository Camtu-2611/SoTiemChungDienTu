using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vaccine_managerment.common;

namespace vaccine_managerment.infrastructure
{
    public interface ICTSoTiemDL:IBaseDL<CTSoTiem>
    {
        /// <summary>
        /// Lấy thông tin CT sổ tiêm theo mã sổ tiêm
        /// </summary>
        /// <param name="masotiem">mã sổ tiêm</param>
        /// <returns></returns>
        /// CreatedBy: nctu 1.05.2022
        public IEnumerable<CTSoTiem> GetCTSoTiemByCode(string masotiem);
    }
}
