using System.Collections.Generic;
using CopaFilmes.WebApi.DTOs;

namespace CopaFilmes.WebApi.Services.Interfaces
{
    public interface ICompeticaoService
    {
        public IDictionary<string,FilmeDto> IniciarCompeticao(IEnumerable<FilmeDto> competidores);
    }
}