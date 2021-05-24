using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Usuario.Core;
using Usuario.Domain;

namespace Usuario.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize("Bearer")]
    public class UsuarioController : ControllerBase
    {
        private UsuarioService _service;

        public UsuarioController(UsuarioService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<ApplicationUser> Get()
        {
            return _service.ListarTodos();
        }

        [HttpGet("{email}")]
        public ActionResult<ApplicationUser> Get(string email)
        {
            var produto = _service.Obter(email);
            if (produto != null)
                return produto;
            else
                return NotFound();
        }

        [HttpPost]
        public IActionResult Post([FromBody] ApplicationUser user)
        {
            if (_service.Incluir(user)) return Ok();

            return BadRequest();
        }

        [HttpPut]
        public IActionResult Put([FromBody] ApplicationUser user)
        {
            if (_service.Atualizar(user)) return Ok();

            return BadRequest();
        }

        [HttpDelete("{email}")]
        public IActionResult Delete(string email)
        {
            if (_service.Excluir(email)) return Ok();

            return BadRequest();
        }
    }
}