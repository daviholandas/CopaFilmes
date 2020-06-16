using System;
using System.Collections.Generic;
using System.Text;
using CopaFilmes.WebApi.DomainObjects;
using CopaFilmes.WebApi.Models;
using Xunit;
using Xunit.Sdk;

namespace CopaFilmes.Tests
{
    public class FilmeTests
    {
        [Fact(DisplayName = "TESTE IGUALDADE FILMES IGUAIS.")]
        public void Filme_TesteIgualdade_DeveRetornarTrue()
        {
            //Arrange
            var filme1 = new Filme("A1", "Filme A", 2019, 5.0);
            var filme2 = new Filme("A1", "Filme A", 2019, 5.0);
            //Act
           
            //Assert
            Assert.True(filme1.Equals(filme2));
            Assert.True(filme1 == filme2);
        }

        [Fact(DisplayName = "TESTE IGUALDADE FILMES DIFERENTES" )]
        public void Filme_TesteIgualdade_DeveRetornarFalse()
        {
            //Arrange
            var filme1 = new Filme("A1", "Filme A", 2019, 5.0);
            var filme2 = new Filme("A2", "Filme A", 2019, 5.0);
            //Act
           
            //Assert
            Assert.False(filme1.Equals(filme2));
            Assert.True(filme1 != filme2);
        }

        [Fact(DisplayName = "TESTE DE VALIDAÇÃO DE ENTIDADE, Id nulo.")]
        public void Filme_ValidacaoDeDominio_IdNuloDeveRetornarException()
        {
            //Arrange & Act
            var ex = Assert.Throws<DomainException>(() => new Filme(null, "Filme A", 2009, 4));
            
            //Assert
            Assert.Equal("Id não pode ser nulo ou está em branco.", ex.Message);
        }

        [Fact(DisplayName = "TESTE DE VALIDAÇÃO DE ENTIDADE, Nome nulo.")]
        public void Filme_ValidacaoDeDominio_NomeNuloDeveRetornarException()
        {
            //Arrange & Act
            var ex = Assert.Throws<DomainException>(() => new Filme("A1", null, 2009, 4));

            //Assert
            Assert.Equal("Titulo do filme não poder ser nulo ou está em branco.", ex.Message);
        }
    }
}
