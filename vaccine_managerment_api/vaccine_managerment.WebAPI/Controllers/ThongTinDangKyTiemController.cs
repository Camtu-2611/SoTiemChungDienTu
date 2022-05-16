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
    public class ThongTinDangKyTiemController : BaseEntityController<ThongTinDangKyTiem>
    {
        private IThongTinDangKyTiemBL _thongtindangkytiemBL;
        public ThongTinDangKyTiemController(IThongTinDangKyTiemBL thongtindangtiemBL) : base(thongtindangtiemBL)
        {
            _thongtindangkytiemBL = thongtindangtiemBL;
        }
        /// <summary>
        /// API lấy thông tin đăng ký theo số điện thoại 
        /// </summary>
        /// <param name="phonenumber">số điện thoại </param>
        /// <returns></returns>
        /// CreatedBy: nctu 30.04.2022
        [HttpGet("byphonenumber/{phonenumber}")]
        public IActionResult GetThongTinDangKyTiemByPhoneNumber(string phonenumber)
        {
            var responseResult = new ServiceResult();
            try
            {
                responseResult = _thongtindangkytiemBL.GetThongTinDangKyTiemByPhoneNumber(phonenumber);

            }
            catch (Exception)
            {
                responseResult.OnBadRequest(responseResult);
                return StatusCode(StatusCodes.Status400BadRequest, responseResult);
                throw;
            }

            return StatusCode(StatusCodes.Status200OK, responseResult);
        }

        /// <summary>
        /// API lấy thông tin đăng ký theo mã sổ tiêm
        /// </summary>
        /// <param name="masotiem">mã sổ tiêm </param>
        /// <returns></returns>
        /// CreatedBy: nctu 30.04.2022
        [HttpGet("bycode/{masotiem}")]
        public IActionResult GetThongTinDangKyTiemByCode(string masotiem)
        {
            var responseResult = new ServiceResult();
            try
            {
                responseResult = _thongtindangkytiemBL.GetThongTinDangKyTiemByCode(masotiem);

            }
            catch (Exception)
            {
                responseResult.OnBadRequest(responseResult);
                return StatusCode(StatusCodes.Status400BadRequest, responseResult);
                throw;
            }

            return StatusCode(StatusCodes.Status200OK, responseResult);
        }
    }
}
