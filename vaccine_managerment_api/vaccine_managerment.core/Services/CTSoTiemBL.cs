using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vaccine_managerment.common;
using vaccine_managerment.infrastructure;

namespace vaccine_managerment.core
{
    public class CTSoTiemBL : BaseBL<CTSoTiem>, ICTSoTiemBL
    {
        private ICTSoTiemDL _ctsotiemDL;
        public CTSoTiemBL(ICTSoTiemDL ctsotiemDL) : base(ctsotiemDL)
        {
            _ctsotiemDL = ctsotiemDL;
        }

        /// <summary>
        /// Lấy thông tin CT sổ tiêm theo mã sổ tiêm
        /// </summary>
        /// <param name="masotiem">mã sổ tiêm</param>
        /// <returns></returns>
        /// CreatedBy: nctu 11.05.2022
        public ServiceResult GetCTSoTiemByCode(string masotiem)
        {
            var entity = _ctsotiemDL.GetCTSoTiemByCode(masotiem);

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
