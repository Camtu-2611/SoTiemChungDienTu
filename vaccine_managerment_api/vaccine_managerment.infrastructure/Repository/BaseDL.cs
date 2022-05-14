using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;

namespace vaccine_managerment.infrastructure
{
    public class BaseDL<T> : IBaseDL<T>
    {
        //Tên của đối tượng
        protected string _tableName = string.Empty;

        //Chuỗi kết nối đến CSDL
        protected string _connectionString = "Data Source=NCTU2;Initial Catalog=Vaccine_management;Integrated Security=True";

        //Khai báo kết nối
        protected IDbConnection _dbConnection;

        public BaseDL()
        {
            _tableName = typeof(T).Name;
            _dbConnection = new SqlConnection(_connectionString);
        }

        public IEnumerable<T> GetEntities()
        {
            // Thực hiện lấy dữ liệu từ Database
            var entities = _dbConnection.Query<T>(
                $"Proc_Get{_tableName}",
                commandType: CommandType.StoredProcedure);
            return entities;
        }
        public T GetById(Guid entityId)
        {
            // Thực hiện lấy thông tin một đối tượng
            var storeName = $"Proc_Get{_tableName}ById";
            var storeGetByIdParamName = "";
            DynamicParameters dynamicParameters = new DynamicParameters();
            if (_tableName == "ThongTinDangKyTiem")
            {
                storeGetByIdParamName = $"@iddangky";
            }
            else if( _tableName == "NhanVien")
            {
                storeGetByIdParamName = $"@idnhanvien";
            }
            else
            {
                storeGetByIdParamName = $"@id{_tableName.ToLower()}";
            }
            dynamicParameters.Add(storeGetByIdParamName, entityId);

            var entity = _dbConnection.Query<T>(
                storeName,
                dynamicParameters,
                commandType: CommandType.StoredProcedure)
                .FirstOrDefault();
            return entity;
        }
        public T GetByCode(string entityCode)
        {
            // Thực hiện lấy thông tin một đối tượng
            var storeName = $"Proc_Get{_tableName}ByCode";

            DynamicParameters dynamicParameters = new DynamicParameters();
            var storeGetByCodeParamName = $"@ma{_tableName.ToLower()}";
            dynamicParameters.Add(storeGetByCodeParamName, entityCode);

            var entity = _dbConnection.Query<T>(
                storeName,
                dynamicParameters,
                commandType: CommandType.StoredProcedure)
                .FirstOrDefault();
            return entity;
        }

        public int Insert(T entity)
        {
            var keyprop = GetKeyProperty();
            var keyValue = keyprop.GetValue(entity);
            if (keyValue == null || keyValue.ToString() == "" || keyValue.ToString() == Guid.Empty.ToString())
            {
                var newValue = Guid.NewGuid();
                keyprop.SetValue(entity, newValue);
            }
            var storeName = $"Proc_Insert{_tableName}";
            var storeParam = entity;
            var rowAffects = _dbConnection.Execute(storeName,
                param: storeParam,
                commandType: CommandType.StoredProcedure);
            return rowAffects;
        }

        public int Update(T entity, Guid entityId)
        {
            // thực hiện cập nhật cơ sở dữ liệu
            var storeName = $"Proc_Update{_tableName}";
            //var storeParam = entity;
            var keyProperty = GetKeyProperty();
            var properties = typeof(T).GetProperties();
            var storeParam = new DynamicParameters();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                if (property.Name == keyProperty.Name)
                {
                    continue;
                }
                var propertyValue = property.GetValue(entity);
                storeParam.Add($"@{propertyName}", propertyValue);

            }
            storeParam.Add($"@{keyProperty.Name}", entityId);
            var rowAffects = _dbConnection.Execute(
                storeName,
                param: storeParam,
                commandType: CommandType.StoredProcedure);

            return rowAffects;
        }

        public int Delete(Guid entityId)
        {
            // Thực hiện xóa dữ liệu từ Database:
            var storeName = $"Proc_Delete{_tableName}";
            var keyProperty = GetKeyProperty();
            var storeParam = new Dictionary<string, object>
            {
                { keyProperty.Name, entityId }
            };
            var rowEffects = _dbConnection.Execute(
                storeName,
                param: storeParam,
                commandType: CommandType.StoredProcedure);
            return rowEffects;
        }

        /// <summary>
        /// Lấy ra khóa chính của đối tượng
        /// </summary>
        /// <returns>thuộc tính là khóa chính của đối tượng</returns>
        /// CreatedBy: 14.04.2021
        public PropertyInfo GetKeyProperty()
        {
            var keyProperty = typeof(T)
                .GetProperties()
                .Where(p => p.IsDefined(typeof(KeyAttribute), false))
                .FirstOrDefault();
            return keyProperty;
        }
    }
}
