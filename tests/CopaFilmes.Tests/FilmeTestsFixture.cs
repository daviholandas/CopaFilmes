using CopaFilmes.WebApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using CopaFilmes.WebApi.DTOs;
using Xunit;

namespace CopaFilmes.Tests
{
    [CollectionDefinition(nameof(FilmeFixtureCollection))]
    public class FilmeFixtureCollection : ICollectionFixture<FilmeTestsFixture>{}
    
    public class FilmeTestsFixture
    {
        public async Task<IEnumerable<Filme>> GerarColecaoDeFilmes(int quantidade)
        {
            var pathArquivo = @"C:\Users\davi_\source\repos\CopaFilmes\tests\CopaFilmes.Tests\Data\filmes.json";
            using (var json = File.OpenRead(pathArquivo))
            {
                var filmesFetched = await JsonSerializer.DeserializeAsync<IEnumerable<FilmeDto>>(json);

                return (from filme in filmesFetched select new Filme(filme.Id, filme.Titulo, filme.Ano, filme.Nota))
                    .Take(quantidade);
            }
           
        }

        public async Task<Competicao> GerarCompeticao()
        {
            var competidores = await GerarColecaoDeFilmes(8);
            var competidoresOrdemAlfabetica = competidores.OrderBy(f => f.Titulo);
            var competicao = new Competicao(competidoresOrdemAlfabetica);

            return competicao;
        }
        
    }
}
