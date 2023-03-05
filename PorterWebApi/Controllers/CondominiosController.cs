using Microsoft.AspNetCore.Mvc;
using PorterWebApi.Application.Interfaces;
using PorterWebApi.Domain.Entities;
using System;
using System.Collections.Generic;

namespace PorterWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CondominiosController : ControllerBase
    {
        private readonly ICondominioAppService _condominioAppService;

        public CondominiosController(ICondominioAppService condominioAppService)
        {
            _condominioAppService = condominioAppService;
        }

        // GET: api/<CondominioController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<Condominio> condominios = _condominioAppService.GetAll();

                return Ok(condominios);
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException?.Message??e.Message);
            }
            
        }

        // GET api/<CondominioController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                Condominio condominio = _condominioAppService.GetById(id);

                return Ok(condominio);
            }

            catch (Exception e)
            {
                return BadRequest(e.InnerException?.Message??e.Message);
            }
        }

        // POST api/<CondominioController>
        [HttpPost]
        public IActionResult Post([FromBody] Condominio condominio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            try
            {
                _condominioAppService.Add(condominio);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException?.Message??e.Message);
            }
        }

        // PUT api/<CondominioController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Condominio condominio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            try
            {
                condominio.CondominioId = id;
                _condominioAppService.Update(condominio);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException?.Message??e.Message);
            }
        }

        // DELETE api/<CondominioController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _condominioAppService.Delete(id);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException?.Message??e.Message);
            }
        }
    }
}
