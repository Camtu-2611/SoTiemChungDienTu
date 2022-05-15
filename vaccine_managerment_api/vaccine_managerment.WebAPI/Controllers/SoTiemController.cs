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
    public class SoTiemController : BaseEntityController<SoTiem>
    {
        private ISoTiemBL _sotiemBL;

        public SoTiemController(ISoTiemBL sotiemBL): base(sotiemBL)
        {
            _sotiemBL = sotiemBL;
        }

        /// <summary>
        /// API lấy thông tin sổ tiêm theo mã sổ tiêm
        /// </summary>
        /// <param name="masotiem">mã sổ tiêm </param>
        /// <returns></returns>
        /// CreatedBy: nctu 05.05.2022
        [HttpGet("bycode/{masotiem}")]
        public IActionResult GetSoTiemByCode(string masotiem)
        {
            var responseResult = new ServiceResult();
            try
            {
                responseResult = _sotiemBL.GetSoTiemByCode(masotiem);

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
        /// API generate mã sổ tiêm mới nhất
        /// </summary>
        /// <param name="masotiem">mã sổ tiêm </param>
        /// <returns></returns>
        /// CreatedBy: nctu 05.05.2022
        [HttpGet("generateCode")]
        public IActionResult GenerateMaSoTiem()
        {
            var responseResult = new ServiceResult();
            try
            {
                var ngayhientai = DateTime.Now;
                if(ngayhientai > DateTime.MinValue && ngayhientai < DateTime.MaxValue)
                {

                int namhientai = ngayhientai.Year;
                int thanghientai = ngayhientai.Month;
                responseResult = _sotiemBL.GenerateMaSoTiem(namhientai, thanghientai);

                }
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
