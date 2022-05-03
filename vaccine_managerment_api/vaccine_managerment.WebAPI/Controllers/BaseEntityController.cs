using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vaccine_managerment.common;
using vaccine_managerment.core;

namespace vaccine_managerment.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseEntityController<T> : ControllerBase
    {
        private IBaseBL<T> _baseBL;

        #region Khởi tạo
        public BaseEntityController(IBaseBL<T> baseService)
        {
            _baseBL = baseService;
        }
        #endregion

        #region API
        // GET: api/<BaseController>
        /// <summary>
        /// API lấy toàn bộ danh sách thực thể
        /// </summary>
        /// <returns>Danh sách thực thể</returns>
        /// CreatedBy: nctu 30.04.2022
        [HttpGet]
        public IActionResult Get()
        {
            var responseResult = _baseBL.GetEntities();
            return StatusCode(StatusCodes.Status200OK, responseResult);

        }

        // GET api/<BaseController>/5
        /// <summary>
        /// API lấy một thực thể theo khóa chính
        /// </summary>
        /// <param name="entityId">Khóa chính của thực thể</param>
        /// <returns></returns>
        /// CreatedBy: nctu 30.04.2022
        [HttpGet("{entityId}")]
        public IActionResult Get(Guid entityId)
        {
            var responseResult = new ServiceResult();
            try
            {
                responseResult = _baseBL.GetById(entityId);

            }
            catch (Exception)
            {
                responseResult.OnBadRequest(responseResult);
                return StatusCode(StatusCodes.Status400BadRequest, responseResult);
                throw;
            }

            return StatusCode(StatusCodes.Status200OK, responseResult);
        }

        // POST api/<BaseController>
        /// <summary>
        /// API thêm một thực thể
        /// </summary>
        /// <param name="entity">Thông tin thực thể cần thêm</param>
        /// <returns></returns>
        /// CreatedBy: nctu 30.04.2022
        [HttpPost]
        public IActionResult Post([FromBody] T entity)
        {
            var responseResult = new ServiceResult();
            try
            {
                responseResult = _baseBL.Insert(entity);
            }
            catch (Exception)
            {
                responseResult.OnBadRequest(responseResult);
                //return StatusCode(int.Parse(responseResult.ErrorCode.ToString()), responseResult);
                throw;
            }

            return StatusCode(StatusCodes.Status201Created, responseResult);
        }

        // PUT api/<BaseController>/5
        /// <summary>
        /// API sửa thông tin một thực thể
        /// </summary>
        /// <param name="entityId">Khóa chính của thực thể</param>
        /// <param name="entity">Thông tin cần sửa của thực thể</param>
        /// <returns></returns>
        [HttpPut("{entityId}")]
        public IActionResult Put(Guid entityId, [FromBody] T entity)
        {
            var responseResult = new ServiceResult();
            try
            {
                responseResult = _baseBL.Update(entity, entityId);

            }
            catch (Exception)
            {
                responseResult.OnBadRequest(responseResult);
                return StatusCode(int.Parse(responseResult.ErrorCode.ToString()), responseResult);
                throw;
            }
            return StatusCode(StatusCodes.Status200OK, responseResult);

        }

        // DELETE api/<BaseController>/5
        /// <summary>
        /// Xóa thông tin một thực thể theo khóa chính
        /// </summary>
        /// <param name="entityId">Khóa chính của thực thể</param>
        /// <returns></returns>
        [HttpDelete("{entityId}")]
        public IActionResult Delete(Guid entityId)
        {
            var responseResult = new ServiceResult();
            try
            {
                responseResult = _baseBL.Delete(entityId);

            }
            catch (Exception)
            {
                //return StatusCode(int.Parse(responseResult.ErrorCode.ToString()), responseResult);
                throw;
            }
            return StatusCode(StatusCodes.Status200OK, responseResult);

        }
        #endregion
    }
}
