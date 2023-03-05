using Microsoft.AspNetCore.Mvc;
using PorterWebApi.Application.Interfaces;
using PorterWebApi.Domain.Entities;
using System;
using System.Collections.Generic;

namespace PorterWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoradoresController : ControllerBase
    {
        private readonly IMoradorAppService _moradorAppService;

        public MoradoresController(IMoradorAppService moradorAppService)
        {
            _moradorAppService = moradorAppService;
        }

        // GET: api/<MoradoresController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<Morador> moradors = _moradorAppService.GetAll();

                return Ok(moradors);
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException?.Message??e.Message);
            }

        }

        // GET api/<MoradoresController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                Morador morador = _moradorAppService.GetById(id);

                return Ok(morador);
            }

            catch (Exception e)
            {
                return BadRequest(e.InnerException?.Message??e.Message);
            }
        }

        // POST api/<MoradoresController>
        [HttpPost]
        public IActionResult Post([FromBody] Morador morador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _moradorAppService.Add(morador);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException?.Message??e.Message);
            }
        }

        // PUT api/<MoradoresController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Morador morador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            try
            {
                morador.MoradorId = id;
                _moradorAppService.Update(morador);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException?.Message??e.Message);
            }
        }

        // DELETE api/<MoradoresController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _moradorAppService.Delete(id);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException?.Message??e.Message);
            }
        }
    }
}
