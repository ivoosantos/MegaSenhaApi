using MegaSenhaApi.Helper;
using MegaSenhaApi.Models;
using MegaSenhaApi.Repositories.Contratos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaSenhaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PalavrasController : ControllerBase
    {
        private readonly IPalavraRepository _repository;
        public PalavrasController(IPalavraRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("", Name = "ObterTodas")]
        public ActionResult ObterTodas([FromQuery]PalavraUrlQuery query)
        {
            var item = _repository.GetPalavra(query);
            if (item.Count() < 1)
                return NotFound();

            return Ok(item);
        }

        [HttpGet("{id}", Name = "ObterPalavra")]
        public ActionResult Obter(int id)
        {
            var obj = _repository.Obter(id);

            if (obj == null)
                return NotFound();

            return Ok(obj);
        }

        [Route("")]
        [HttpPost]
        public ActionResult Cadastrar([FromBody]Palavra palavra)
        {
            if (palavra == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            palavra.Ativo = true;
            palavra.Criado = DateTime.Now;
            _repository.Cadastrar(palavra);

            return Created($"/api/palavras/{palavra.Id}", palavra);
        }
    }
}
