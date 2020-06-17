using CopaFilmes.WebApi.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CopaFilmes.WebApi.Models;
using CopaFilmes.WebApi.Services.Interfaces;

namespace CopaFilmes.WebApi.V1.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v1/[controller]")]
    public class CompeticaoController : ControllerBase
    {
        private readonly ICompeticaoService _competicaoService;

        public CompeticaoController(ICompeticaoService competicaoService)
        {
            _competicaoService = competicaoService;
        }
        
        [HttpPost]
        public async Task<ActionResult<IDictionary<string, FilmeDto>>> IniciarCompeticao(IList<FilmeDto> competidores)
        {
            if (competidores.Count() != 8)
                return BadRequest("O numero de competidores deve ser 8.");

            var resultado = _competicaoService.IniciarCompeticao(competidores);
            
            return Ok(resultado);
        }
    }
}