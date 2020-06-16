using System;
using System.Collections.Generic;
using System.Text;
using CopaFilmes.WebApi.Models;
using Xunit;

namespace CopaFilmes.Tests
{
    public class PartidaTests
    {
        [Fact(DisplayName = "ESCOLHER FILME MAIOR NOTA.")]
        public void Partida_EscolherVencedor_DeveRetornarFilmeMaiorNota()
        {
            //Arrange
            var filmeA = new Filme("A1", "FILME A", 2019, 6.9);
            var filmeB = new Filme("A2", "FILME B", 2019, 6.7);

            var partida = new Partida(filmeA, filmeB);
            //Act
            var vencedor = partida.EscolherVencedor();
            //Assert
            Assert.Equal(filmeA, vencedor);
            Assert.NotEqual(filmeB, vencedor);
        }

        [Fact(DisplayName = "ESCOLHER FILME ORDEM ALFABETICA.")]
        public void Partida_EscolherVencedor_FilmesNotasIguaisDeveRetornarOrdemAlfabetica()
        {
            //Arrange
            var filmeA = new Filme("A1", "FILME A", 2019, 6.9);
            var filmeB = new Filme("A2", "FILME B", 2019, 6.9);

            var partida = new Partida(filmeA, filmeB);
            //Act
            var vencedor = partida.EscolherVencedor();
            //Assert
            Assert.Equal(filmeA, vencedor);
        }   
    }
}
