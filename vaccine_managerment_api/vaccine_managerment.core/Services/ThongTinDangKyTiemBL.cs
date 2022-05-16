using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vaccine_managerment.common;
using vaccine_managerment.infrastructure;

namespace vaccine_managerment.core
{
    public class ThongTinDangKyTiemBL:BaseBL<ThongTinDangKyTiem>, IThongTinDangKyTiemBL
    {
        private IThongTinDangKyTiemDL _thongtindangkytiemDL;
        public ThongTinDangKyTiemBL(IThongTinDangKyTiemDL thongtindangkytiemDL) : base(thongtindangkytiemDL)
        {
            _thongtindangkytiemDL = thongtindangkytiemDL;
        }

        /// <summary>
        /// Lấy thông tin đăng ký theo số điện thoại
        /// </summary>
        /// <param name="phonenumber">số điện thoại</param>
        /// <returns></returns>
        /// CreatedBy: nctu 1.05.2022
        public ServiceResult GetThongTinDangKyTiemByPhoneNumber(string phonenumber)
        {
            var entity = _thongtindangkytiemDL.GetThongTinDangKyTiemByPhoneNumber(phonenumber);

            var result = new ServiceResult();
            if (entity != null)
            {
                result.Data = entity;
                result.ErrorCode = ErrorCode.NONE;
                result.UserMsg = common.Resources.Messages.Success;
            }
            else
            {
                result.IsSuccess = false;
                result.UserMsg = common.Resources.Messages.NoContent;
                result.DevMsg = common.Resources.Messages.NoContent;
                result.ErrorCode = ErrorCode.NOCONTENT;
            }

            return result;
        }

        /// <summary>
        /// Lấy thông tin đăng ký theo mã sổ tiêm
        /// </summary>
        /// <param name="masotiem">mã sổ tiêm</param>
        /// <returns></returns>
        /// CreatedBy: nctu 1.05.2022
        public ServiceResult GetThongTinDangKyTiemByCode(string masotiem)
        {
            var entity = _thongtindangkytiemDL.GetThongTinDangKyTiemByCode(masotiem);

            var result = new ServiceResult();
            if (entity != null)
            {
                result.Data = entity;
                result.ErrorCode = ErrorCode.NONE;
                result.UserMsg = common.Resources.Messages.Success;
            }
            else
            {
                result.IsSuccess = false;
                result.UserMsg = common.Resources.Messages.NoContent;
                result.DevMsg = common.Resources.Messages.NoContent;
                result.ErrorCode = ErrorCode.NOCONTENT;
            }

            return result;
        }
    }
}
