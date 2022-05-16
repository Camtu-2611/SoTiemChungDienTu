using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vaccine_managerment.common;

namespace vaccine_managerment.infrastructure
{
    public class ThongTinDangKyTiemDL:BaseDL<ThongTinDangKyTiem>, IThongTinDangKyTiemDL
    {
        /// <summary>
        /// Lấy thông tin đăng ký theo số điện thoại
        /// </summary>
        /// <param name="phonenumber">số điện thoại</param>
        /// <returns></returns>
        /// CreatedBy: nctu 1.05.2022
        public IEnumerable<ThongTinDangKyTiem> GetThongTinDangKyTiemByPhoneNumber(string phonenumber)
        {
            // Thực hiện lấy thông tin một đối tượng
            var storeName = $"Proc_GetThongTinDangKyTiemByNumberPhone";

            DynamicParameters dynamicParameters = new DynamicParameters();
            var storeGetByCodeParamName = $"@sodienthoai";
            dynamicParameters.Add(storeGetByCodeParamName, phonenumber);

            var entity = _dbConnection.Query<ThongTinDangKyTiem>(
                storeName,
                dynamicParameters,
                commandType: CommandType.StoredProcedure);
            return entity;
        }

        /// <summary>
        /// Lấy thông tin đăng ký theo mã sổ tiêm
        /// </summary>
        /// <param name="masotiem">mã sổ tiêm</param>
        /// <returns></returns>
        /// CreatedBy: nctu 1.05.2022
        public IEnumerable<ThongTinDangKyTiem> GetThongTinDangKyTiemByCode(string masotiem)
        {
            // Thực hiện lấy thông tin một đối tượng
            var storeName = $"Proc_GetThongTinDangKyTiemByCode";

            DynamicParameters dynamicParameters = new DynamicParameters();
            var storeGetByCodeParamName = $"@masotiem";
            dynamicParameters.Add(storeGetByCodeParamName, masotiem);

            var entity = _dbConnection.Query<ThongTinDangKyTiem>(
                storeName,
                dynamicParameters,
                commandType: CommandType.StoredProcedure);
            return entity;
        }
    }
}
