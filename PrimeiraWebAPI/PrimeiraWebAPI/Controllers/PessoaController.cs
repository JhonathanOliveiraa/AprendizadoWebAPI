using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace MinhaPrimeiraAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoaController : ControllerBase
    {
        private static List<string> pessoas = new List<string>();

        private readonly ILogger<PessoaController> _logger;

        public PessoaController(ILogger<PessoaController> logger)
        {
            _logger = logger;
        }

        [HttpGet("getPessoa")]
        public IActionResult GetPessoas()
        {
            return Ok(pessoas);
        }

        [HttpPost("criarPessoa")]
        public IActionResult CriarPessoa([FromBody] string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                return BadRequest(new { Message = "Nome não pode estar vazio!" });
            }

            pessoas.Add(nome);
            return Ok(new { Message = "Pessoa criada com sucesso!", Nome = nome });
        }
    }
}