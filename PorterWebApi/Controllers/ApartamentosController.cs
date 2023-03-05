using Microsoft.AspNetCore.Mvc;
using PorterWebApi.Application.Interfaces;
using PorterWebApi.Domain.Entities;
using System;
using System.Collections.Generic;

namespace PorterWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartamentosController : ControllerBase
    {
        private readonly IApartamentoAppService _apartamentoAppService;

        public ApartamentosController(IApartamentoAppService apartamentoAppService)
        {
            _apartamentoAppService = apartamentoAppService;
        }

        // GET: api/<ApartamentoController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<Apartamento> apartamentos = _apartamentoAppService.GetAll();

                return Ok(apartamentos);
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException?.Message??e.Message);
            }

        }

        // GET api/<ApartamentoController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                Apartamento apartamento = _apartamentoAppService.GetById(id);

                return Ok(apartamento);
            }

            catch (Exception e)
            {
                return BadRequest(e.InnerException?.Message??e.Message);
            }
        }

        // POST api/<ApartamentoController>
        [HttpPost]
        public IActionResult Post([FromBody] Apartamento apartamento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _apartamentoAppService.Add(apartamento);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException?.Message??e.Message);
            }
        }

        // PUT api/<ApartamentoController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Apartamento apartamento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            try
            {
                apartamento.ApartamentoId = id;
                _apartamentoAppService.Update(apartamento);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException?.Message??e.Message);
            }
        }

        // DELETE api/<ApartamentoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _apartamentoAppService.Delete(id);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException?.Message??e.Message);
            }
        }
    }
}
