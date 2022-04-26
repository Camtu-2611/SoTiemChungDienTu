using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoTiemChungDienTu.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoTiemChungDienTu.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseEntityController<T> : ControllerBase
    {
        private IBaseService<T> _baseService;

        public BaseEntityController(IBaseService<T> baseService)
        {
            _baseService = baseService;
        }

        // GET: api/<BaseController>
        [HttpGet]
        public IActionResult Get()
        {
            var responseResult = _baseService.GetEntities();
            return Ok(responseResult);
        }


        // GET api/<BaseController>/5
        [HttpGet("{entityId}")]
        public IActionResult Get(Guid entityId)
        {
            var responseResult = _baseService.GetById(entityId);

            return Ok(responseResult);
        }

        // POST api/<BaseController>
        [HttpPost]
        public IActionResult Post([FromBody] T entity)
        {
            var responseResult = _baseService.Insert(entity);

            return Ok(responseResult);
        }

        // PUT api/<BaseController>/5
        [HttpPut("{entityId}")]
        public IActionResult Put(Guid entityId, [FromBody] T entity)
        {
            var responseResult = _baseService.Update(entity, entityId);
            return Ok(responseResult);
        }

        // DELETE api/<BaseController>/5
        [HttpDelete("{entityId}")]
        public IActionResult Delete(Guid entityId)
        {
            var responseResult = _baseService.Delete(entityId);
            return Ok(responseResult);
        }
    }
}
