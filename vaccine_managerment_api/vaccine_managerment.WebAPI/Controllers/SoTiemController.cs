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
    }
}
