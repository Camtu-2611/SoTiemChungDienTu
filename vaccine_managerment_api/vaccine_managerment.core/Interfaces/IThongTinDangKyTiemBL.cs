using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vaccine_managerment.common;

namespace vaccine_managerment.core
{
    public interface IThongTinDangKyTiemBL:IBaseBL<ThongTinDangKyTiem>
    {
        /// <summary>
        /// Lấy thông tin đăng ký theo số điện thoại
        /// </summary>
        /// <param name="phonenumber">số điện thoại</param>
        /// <returns></returns>
        /// CreatedBy: nctu 1.05.2022
        public ServiceResult GetThongTinDangKyTiemByPhoneNumber(string phonenumber);

        /// <summary>
        /// Lấy thông tin đăng ký theo mã sổ tiêm
        /// </summary>
        /// <param name="masotiem">mã sổ tiêm</param>
        /// <returns></returns>
        /// CreatedBy: nctu 1.05.2022
        public ServiceResult GetThongTinDangKyTiemByCode(string masotiem);
    }
}
