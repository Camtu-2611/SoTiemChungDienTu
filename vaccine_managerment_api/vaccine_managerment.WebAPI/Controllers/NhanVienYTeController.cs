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
    public class NhanVienYTeController : BaseEntityController<NhanVienYTe>
    {
        private INhanVienYTeBL _nhanvienyteBL;

        public NhanVienYTeController(INhanVienYTeBL nhanvienyteBL) : base(nhanvienyteBL)
        {
            _nhanvienyteBL = nhanvienyteBL;
        }
    }
}
