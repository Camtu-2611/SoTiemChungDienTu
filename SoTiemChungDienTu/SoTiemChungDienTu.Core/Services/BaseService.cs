﻿using MISA.CukCuk.Common;
using SoTiemChungDienTu.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoTiemChungDienTu.Core
{
    public class BaseService<T>:IBaseService<T>
    {
        protected IBaseRepository<T> _baseRespository;

        public BaseService(IBaseRepository<T> baseRespository)
        {
            _baseRespository = baseRespository;
        }

        /// <summary>
        /// Service lấy thông tin 1 thực thể theo khóa chính
        /// </summary>
        /// <param name="entityId">Khóa chính của thực thể</param>
        /// <returns>ServiceResult</returns>
        /// CreatedBy: nctu 12.05.2021
        public ServiceResult GetById(Guid entityId)
        {
            var result = new ServiceResult();
            var entity = _baseRespository.GetById(entityId);
            if (entity != null)
            {
                result.Data = entity;
                result.IsSuccess = true;
                result.ErrorCode = ErrorCode.NONE;
                result.UserMsg = Common.Resources.Messages.Success;
            }
            else
            {
                result.IsSuccess = false;
                result.DevMsg = Common.Resources.Messages.Error_NotExist;
                result.UserMsg = Common.Resources.Messages.Error_NotExist;
            }

            return result;
        }

        /// <summary>
        /// Service lấy danh sách thực thể
        /// </summary>
        /// <returns>ServiceResult</returns>
        /// CreatedBy: nctu 12.05.2021
        public ServiceResult GetEntities()
        {
            var entities = _baseRespository.GetEntities();

            var result = new ServiceResult();
            if (entities != null)
            {
                result.Data = entities;
                result.ErrorCode = ErrorCode.NONE;
                result.UserMsg = Common.Resources.Messages.Success;
            }
            else
            {
                result.IsSuccess = false;
                result.UserMsg = Common.Resources.Messages.NoContent;
                result.DevMsg = Common.Resources.Messages.NoContent;
                result.ErrorCode = ErrorCode.NOCONTENT;
            }

            return result;
        }

        /// <summary>
        /// Service thêm thực thể
        /// </summary>
        /// <param name="entity">Thực thể cần thêm</param>
        /// <returns>ServiceResult</returns>
        /// CreatedBy: nctu 12.05.2021
        public ServiceResult Insert(T entity)
        {
            var result = new ServiceResult();
            string functionName = "Insert";

            // Validate nghiệp vụ
            Validate(result, entity, null, functionName);

            if (result.IsSuccess == true)
            {
                // Thực hiện thêm mới
                var rowAffects = _baseRespository.Insert(entity);

                if (rowAffects == 1)
                {
                    result.IsSuccess = true;
                    result.ErrorCode = ErrorCode.NONE;
                    result.UserMsg = Common.Resources.Messages.Success;
                }
                else
                {
                    result.IsSuccess = false;
                    result.ErrorCode = ErrorCode.EXCEPTION;
                    result.DevMsg = Common.Resources.Messages.Error_Insert;
                    result.UserMsg = Common.Resources.Messages.Error_Insert;
                }
            }

            return result;
        }

        /// <summary>
        /// Service cập nhật thông tin 1 thực thể
        /// </summary>
        /// <param name="entity">Thông tin cần cập nhật</param>
        /// <param name="entityId">Khóa chính của thực thể</param>
        /// <returns>ServiceResult</returns>
        /// CreatedBy: nctu 12.05.2021
        public ServiceResult Update(T entity, Guid entityId)
        {
            var result = new ServiceResult();
            string functionName = "Update";

            //Validate nghiệp vụ khi cập nhật

            Validate(result, entity, entityId, functionName);

            if (result.IsSuccess == true)
            {
                // thực hiện cập nhật
                var rowAffects = _baseRespository.Update(entity, entityId);

                if (rowAffects == 1)
                {
                    result.IsSuccess = true;
                    result.ErrorCode = ErrorCode.NONE;
                    result.UserMsg = Common.Resources.Messages.Success;

                }
                else
                {
                    result.IsSuccess = false;
                    result.ErrorCode = ErrorCode.EXCEPTION;
                    result.DevMsg = Common.Resources.Messages.Error_Update;
                    result.UserMsg = Common.Resources.Messages.Error_Update;

                }
            }
            return result;
        }

        /// <summary>
        /// Service xóa 1 thực thể
        /// </summary>
        /// <param name="entityId">Khóa chính của thực thể cần xóa</param>
        /// <returns>ServiceResult</returns>
        /// CreatedBy: nctu 12.05.2021
        public ServiceResult Delete(Guid entityId)
        {
            var result = new ServiceResult();

            // thực hiện cập nhật
            var rowAffects = _baseRespository.Delete(entityId);

            if (rowAffects == 1)
            {
                result.ErrorCode = ErrorCode.NONE;
                result.IsSuccess = true;
            }
            else
            {
                result.IsSuccess = false;
                result.UserMsg = Common.Resources.Messages.NoContent;
                result.DevMsg = Common.Resources.Messages.NoContent;
                result.ErrorCode = ErrorCode.NOCONTENT;
            }

            return result;
        }

        /// <summary>
        /// Hàm validate dữ liệu
        /// </summary>
        /// <param name="response">Kết quả trả về</param>
        /// <param name="entity">Đối tượng cần validate</param>
        /// <param name="entityID">Khóa chính của đối tượng</param>
        /// <param name="functionName">Tên phương thức gọi hàm validate (insert hay update)</param>
        /// CreatedBy: nctu 13.05.2021
        public virtual void Validate(ServiceResult response, T entity, Guid? entityID, string functionName)
        {
            /* var properties = typeof(T).GetProperties();
            foreach(var property in properties)
            {
                var propValue = property.GetValue(entity);

                if(propValue == null || propValue.ToString() == string.Empty)
                {
                    // nếu là trường required thì đưa ra thông báo lỗi
                    if(property.IsDefined(typeof(RequiredAttribute), true))
                    {
                        var displayName = property
                            .GetCustomAttributes(typeof(RequiredAttribute), false)
                            .OfType<DisplayAttribute>().FirstOrDefault();
                        responseResult.IsSuccess = false;
                        responseResult.ErrorCode = Enum.ErrorCode.BADREQUEST;
                        responseResult.DevMsg = displayName.Name + " " + Resources.ResourceMessage.Error_Required;
                        responseResult.UserMsg = displayName.Name + " " + Resources.ResourceMessage.Error_Required;
                    }
                }
                else
                {
                    // kiểm tra xem trường nào là duy nhất (có thuộc tính Unique) thì check duplicate
                    if(property.IsDefined(typeof(Unique), false))
                    {
                        bool checkDuplicateCode = _baseRespository.CheckDuplicateEntityCode(entity, entityID, functionName);
                        if (checkDuplicateCode)
                        {
                            var displayName = property
                            .GetCustomAttributes(typeof(Unique), false)
                            .OfType<DisplayAttribute>().FirstOrDefault();
                            responseResult.IsSuccess = false;
                            responseResult.ErrorCode = Enum.ErrorCode.BADREQUEST;
                            responseResult.DevMsg = displayName.Name + " " + Resources.ResourceMessage.Error_Duplicate;
                            responseResult.UserMsg = displayName.Name + " " + Resources.ResourceMessage.Error_Duplicate;
                        }
                    }
                }
            }*/


        }
    }
}
