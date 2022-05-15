using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vaccine_managerment.common;

namespace vaccine_managerment.core
{
    public interface ISoTiemBL:IBaseBL<SoTiem>
    {
        /// <summary>
        /// Lấy thông tin sổ tiêm theo mã sổ tiêm
        /// </summary>
        /// <param name="masotiem">mã sổ tiêm</param>
        /// <returns></returns>
        /// CreatedBy: nctu 1.05.2022
        public ServiceResult GetSoTiemByCode(string masotiem);

        /// <summary>
        /// Tạo mã sổ tiêm tự động và không trùng
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: nctu 1.05.2022
        public ServiceResult GenerateMaSoTiem(int na0m, int thang);
    }
}
