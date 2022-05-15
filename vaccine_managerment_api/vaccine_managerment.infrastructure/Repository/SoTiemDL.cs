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

        /// <summary>
        /// Tạo mã sổ tiêm tự động và không trùng
        /// </summary>
        /// <returns></returns>
        public string GenerateMaSoTiem(int nam, int thang)
        {
            var storeName = $"GetLastestMaSoTiem";
            DynamicParameters dynamicParameters = new DynamicParameters();
            string paramValue = "";
            if (thang < 10 && thang>0)
            {
                paramValue = nam.ToString() + '0'+ thang.ToString();
            }
            else
            {
                paramValue = nam.ToString() + thang.ToString();
            }
            var storeParamName = $"@prefix";
            dynamicParameters.Add(storeParamName, paramValue);
            var masotiem = _dbConnection.Query<String>(
                storeName,
                dynamicParameters,
                commandType: CommandType.StoredProcedure).FirstOrDefault();
            var mamoi = "";
            if (!String.IsNullOrEmpty(masotiem))
            {
                mamoi = GenerateMa(masotiem, paramValue);
            }
            return mamoi;
        }

        public string GenerateMa(string ma, string paramValue)
        {
            int prevnum = int.Parse(ma.Substring(ma.Length - 4, 4));
            int newnum = prevnum + 1;
            var padString = newnum.ToString().PadLeft(4, '0');
            var newstring = paramValue + padString;
            return newstring;
        }
    }
}
