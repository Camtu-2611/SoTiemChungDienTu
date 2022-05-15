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
    public class CTSoTiemController : BaseEntityController<CTSoTiem>
    {
        private ICTSoTiemBL _ctsotiemBL;

        public CTSoTiemController(ICTSoTiemBL ctsotiemBL) : base(ctsotiemBL)
        {
            _ctsotiemBL = ctsotiemBL;
        }
        /// <summary>
        /// API lấy thông tin sổ tiêm theo mã sổ tiêm
        /// </summary>
        /// <param name="masotiem">mã sổ tiêm </param>
        /// <returns></returns>
        /// CreatedBy: nctu 05.05.2022
        [HttpGet("bycode/{masotiem}")]
        public IActionResult GetCTSoTiemByCode(string masotiem)
        {
            var responseResult = new ServiceResult();
            try
            {
                responseResult = _ctsotiemBL.GetCTSoTiemByCode(masotiem);

            }
            catch (Exception ex)
            {
                responseResult.OnBadRequest(responseResult);
                //return StatusCode(StatusCodes.Status400BadRequest, responseResult);
                throw;
            }

            return StatusCode(StatusCodes.Status200OK, responseResult);
        }
    }
}
