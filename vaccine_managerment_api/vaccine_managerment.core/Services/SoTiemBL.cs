using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vaccine_managerment.common;
using vaccine_managerment.infrastructure;

namespace vaccine_managerment.core
{
    public class SoTiemBL: BaseBL<SoTiem>, ISoTiemBL
    {
        private ISoTiemDL _sotiemDL;
        public SoTiemBL(ISoTiemDL sotiemDL) : base(sotiemDL)
        {
            _sotiemDL = sotiemDL;
        }

        /// <summary>
        /// Lấy thông tin sổ tiêm theo mã sổ tiêm
        /// </summary>
        /// <param name="masotiem">mã sổ tiêm</param>
        /// <returns></returns>
        /// CreatedBy: nctu 1.05.2022
        public ServiceResult GetSoTiemByCode(string masotiem) { 
            var entity = _sotiemDL.GetSoTiemByCode(masotiem);

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
        /// Tạo mã sổ tiêm tự động và không trùng
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: nctu 1.05.2022
        public ServiceResult GenerateMaSoTiem(int nam, int thang)
        {
            var entity = _sotiemDL.GenerateMaSoTiem(nam, thang);

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
