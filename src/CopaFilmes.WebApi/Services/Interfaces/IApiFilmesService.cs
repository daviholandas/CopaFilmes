using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CopaFilmes.WebApi.DTOs;

namespace CopaFilmes.WebApi.Services.Interfaces
{
    public interface IApiFilmesService
    {
        Task<IEnumerable<FilmeDto>> ObterFilmes();
    }
}
