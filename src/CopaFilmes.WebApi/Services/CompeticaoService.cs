using System.Collections.Generic;
using System.Linq;
using CopaFilmes.WebApi.DTOs;
using CopaFilmes.WebApi.Models;
using CopaFilmes.WebApi.Services.Interfaces;

namespace CopaFilmes.WebApi.Services
{
    public class CompeticaoService : ICompeticaoService
    {
        public IDictionary<string, FilmeDto> IniciarCompeticao(IEnumerable<FilmeDto> competidores)
        {
            var filmes = from filme in competidores
                orderby filme.Titulo
                select new Filme(filme.Id, filme.Titulo, filme.Ano, filme.Nota);
            
            var competicao = new Competicao(filmes);
            competicao.CriarChaveamento();
            competicao.DisputarCompeticao();
            var resultado = competicao.ObterCampeaoEVice();


            return MapeamentoFilmeParaFilmeDto(resultado);

        }

        private IDictionary<string, FilmeDto> MapeamentoFilmeParaFilmeDto(IDictionary<string, Filme> resultado)
        {
            var campeao = new FilmeDto
            {
                Id = resultado["campeao"].Id,
                Titulo = resultado["campeao"].Titulo,
                Ano = resultado["campeao"].Ano,
                Nota = resultado["campeao"].Nota
            };
            var vice = new FilmeDto
            {
                Id = resultado["vice"].Id,
                Titulo = resultado["vice"].Titulo,
                Ano = resultado["vice"].Ano,
                Nota = resultado["vice"].Nota
            };
            
            return new Dictionary<string, FilmeDto>()
            {
                {"campeao", campeao},
                {"vice", vice}
            };
        }
    }
}