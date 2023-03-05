using Microsoft.AspNetCore.Mvc;
using PorterWebApi.Application.Interfaces;
using PorterWebApi.Domain.Entities;
using System;
using System.Collections.Generic;

namespace PorterWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlocosController : ControllerBase
    {
        private readonly IBlocoAppService _blocoAppService;

        public BlocosController(IBlocoAppService blocoAppService)
        {
            _blocoAppService = blocoAppService;
        }

        // GET: api/<BlocoController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<Bloco> blocos = _blocoAppService.GetAll();

                return Ok(blocos);
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException?.Message??e.Message);
            }

        }

        // GET api/<BlocoController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                Bloco bloco = _blocoAppService.GetById(id);

                return Ok(bloco);
            }

            catch (Exception e)
            {
                return BadRequest(e.InnerException?.Message??e.Message);
            }
        }

        // POST api/<BlocoController>
        [HttpPost]
        public IActionResult Post([FromBody] Bloco bloco)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _blocoAppService.Add(bloco);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException?.Message??e.Message);
            }
        }

        // PUT api/<BlocoController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Bloco bloco)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            try
            {
                bloco.BlocoId = id;
                _blocoAppService.Update(bloco);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException?.Message??e.Message);
            }
        }

        // DELETE api/<BlocoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _blocoAppService.Delete(id);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException?.Message??e.Message);
            }
        }
    }
}
