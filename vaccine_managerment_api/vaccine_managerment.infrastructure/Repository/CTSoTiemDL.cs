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
    public class CTSoTiemDL : BaseDL<CTSoTiem>, ICTSoTiemDL
    {
        /// <summary>
        /// Lấy thông tin CT sổ tiêm theo mã sổ tiêm
        /// </summary>
        /// <param name="masotiem">mã sổ tiêm</param>
        /// <returns></returns>
        /// CreatedBy: nctu 1.05.2022
        public IEnumerable<CTSoTiem> GetCTSoTiemByCode(string masotiem)
        {
            // Thực hiện lấy thông tin một đối tượng
            var storeName = $"Proc_GetCTSoTiemByCode";

            DynamicParameters dynamicParameters = new DynamicParameters();
            var storeGetByCodeParamName = $"@masotiem";
            dynamicParameters.Add(storeGetByCodeParamName, masotiem);

            var entity = _dbConnection.Query<CTSoTiem>(
                storeName,
                dynamicParameters,
                commandType: CommandType.StoredProcedure);
            return entity;
        }
    }
}
