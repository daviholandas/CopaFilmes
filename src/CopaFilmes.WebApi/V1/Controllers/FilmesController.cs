using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CopaFilmes.WebApi.DTOs;
using CopaFilmes.WebApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CopaFilmes.WebApi.V1.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v1/[controller]")]
    public class FilmesController : ControllerBase
    {
        private readonly IApiFilmesService _apiFilmesService;

        public FilmesController(IApiFilmesService apiFilmesService)
        {
            _apiFilmesService = apiFilmesService;
        }

        [HttpGet]
        public async Task<IEnumerable<FilmeDto>> ListarFilmes()
            => await _apiFilmesService.ObterFilmes();
    }
}
