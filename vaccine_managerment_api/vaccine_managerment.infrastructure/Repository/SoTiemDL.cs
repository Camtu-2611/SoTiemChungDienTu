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
    public class SoTiemDL : BaseDL<SoTiem>, ISoTiemDL
    {
        /// <summary>
        /// Lấy thông tin sổ tiêm theo mã sổ tiêm
        /// </summary>
        /// <param name="masotiem">mã sổ tiêm</param>
        /// <returns></returns>
        /// CreatedBy: nctu 1.05.2022
        public SoTiem GetSoTiemByCode(string masotiem)
        {
            // Thực hiện lấy thông tin một đối tượng
            var storeName = $"Proc_GetSoTiemByCode";

            DynamicParameters dynamicParameters = new DynamicParameters();
            var storeGetByCodeParamName = $"@masotiem";
            dynamicParameters.Add(storeGetByCodeParamName, masotiem);

            var entity = _dbConnection.Query<SoTiem>(
                storeName,
                dynamicParameters,
                commandType: CommandType.StoredProcedure).FirstOrDefault();
            return entity;
        }
    }
}
