using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CopaFilmes.WebApi.Models;
using Xunit;

namespace CopaFilmes.Tests
{
    [Collection(nameof(FilmeFixtureCollection))]
    public class CompeticaoTests
    {
        private FilmeTestsFixture _filmeTestsFixture;

        public CompeticaoTests(FilmeTestsFixture filmeTestsFixture)
        {
            _filmeTestsFixture = filmeTestsFixture;
        }

        [Fact(DisplayName = "TESTE INICIO COMPETIÇÃO, CRIAR CHAVEAMENTO.")]
        public async void Competicao_CriarChaveamento_DeveRetornarDicionarioNumeroPartidaEPartida()
        {
            //Arrange
            var competidores =  await  _filmeTestsFixture.GerarColecaoDeFilmes(8);

            var competicao = new Competicao(competidores);
            //Act
            var chaveamento = competicao.CriarChaveamento();
            //Assert
            Assert.Equal(4, chaveamento.Count);
        }

        [Fact(DisplayName = "TESTE CHAVEAMENTO, COMPETIDORES OPOSTOS NA COLLECTION SE ENFRENTAM.")]
        public async void Competicao_CriarChaveamento_OsOpostosDaCollectionDevemSeEnfrentar()
        {
            //Arrange
            var competidores = await _filmeTestsFixture.GerarColecaoDeFilmes(8);
            var competidoresOrdemAlfabetica = competidores.OrderBy(c => c.Titulo);
            
            var filmeIndice1 = new Filme("tt5463162", "Deadpool 2", 2018, 8.1);
            var filmeIndice8 = new Filme("tt4154756", "Vingadores: Guerra Infinita", 2018, 8.8);
            var filmeIndice4 = new Filme("tt4881806", "Jurassic World: Reino Ameaçado", 2018, 6.7);
            var filmeIndice5 = new Filme("tt5164214", "Oito Mulheres e um Segredo", 2018, 6.3);
            

            var competicao = new Competicao(competidoresOrdemAlfabetica);
            //Act
            var chaveamento = competicao.CriarChaveamento();
            
            var filmeChaveado1 = chaveamento[1].Competidor1;
            var filmeChaveado8 = chaveamento[1].Competidor2;
            var filmeChaveado4 = chaveamento[4].Competidor1;
            var filmeChaveado5 = chaveamento[4].Competidor2;

            //Assert
            Assert.Equal(filmeIndice1, filmeChaveado1);
            Assert.Equal(filmeIndice8, filmeChaveado8);
            Assert.Equal(filmeIndice4, filmeChaveado4);
            Assert.Equal(filmeIndice5, filmeChaveado5);
        }

        [Fact(DisplayName = "TESTE DAS QUARTAS DE FINAIS.")]
        public async void Competicao_DisputaDasQuartas_DeveRetornarTamanho2()
        {
            //Arrange
            var competicao = await _filmeTestsFixture.GerarCompeticao();
            var chaveamento = competicao.CriarChaveamento();
            //Act

            var segundoChaveamento = competicao.DisputarQuartas(chaveamento);

            //Assert
            Assert.Equal(2, segundoChaveamento.Count());
        }

        [Fact(DisplayName ="TESTE DAS QUARTAS RETORNANDO OS FILMES DA FINAL.")]
        public async void Competicao_DisputarDasQuartas_DeveRetornarOsTimesCertos()
        {
            /*
             Filmes que devem ser retornados Quartas.
                    • "Vingadores: Guerra Infinita"
                    • "Thor: Ragnarok"
                    • "Os Incríveis 2"
                    • "Jurassic World: Reino Ameaçado"
             
             */
            //Arrange
            
            var competicao = await _filmeTestsFixture.GerarCompeticao();
            var chaveameto = competicao.CriarChaveamento();
            var quartas = competicao.DisputarQuartas(chaveameto);

            var filmeIndice1 = new Filme("tt4154756", "Vingadores: Guerra Infinita", 2018, 8.8);
            var filmeIndice4 = new Filme("tt3606756", "Os Incríveis 2", 2018, 8.5);

            //Act
            var competidor1 = quartas[1].Competidor1;
            var competidor3 = quartas[2].Competidor1;
            //Assert
            Assert.Equal(filmeIndice1, competidor1);
            Assert.Equal(filmeIndice4,competidor3);
        }

        [Fact]
        public async void Competicao_Final_DeveRetornarUmaListaCom2Filmes()
        {
            //Arrange
            var competicao = await _filmeTestsFixture.GerarCompeticao();
            var chaveameto = competicao.CriarChaveamento();
            var quartas = competicao.DisputarQuartas(chaveameto);

            //Act
            var competidoresFinal = competicao.DisputarFinal(quartas).Count();
            //Assert
            Assert.Equal(2, competidoresFinal);
        }

        [Fact(DisplayName = "TESTE RESULTADO DOS FINALISTAS.")]
        public async void Competicao_Final_DeveRetornarFilmesCertosFinal()
        {
            //Arrange 
            var competicao = await _filmeTestsFixture.GerarCompeticao();
            var chaveameto = competicao.CriarChaveamento();
            var quartas = competicao.DisputarQuartas(chaveameto);
            var final = competicao.DisputarFinal(quartas);

            var filmeFinalista1 = new Filme("tt4154756", "Vingadores: Guerra Infinita", 2018, 8.8);
            var filmeFinalista2 = new Filme("tt3606756", "Os Incríveis 2", 2018, 8.5);

            //Act
            var finalista1 = final[0];
            var finalista2 = final[1];
            //Assert
            Assert.Equal(filmeFinalista1,finalista1);
            Assert.Equal(filmeFinalista2, finalista2);
        }

        [Fact(DisplayName = "TESTE RESULTADO FINAL COMPETIÇÃO.")]
        public async void Competicao_CriarCompeticao_VaiRetornarCampeaoEVice()
        {
            //Arrange
            var competicao = await _filmeTestsFixture.GerarCompeticao();
            var campeao = new Filme("tt4154756", "Vingadores: Guerra Infinita", 2018, 8.8);
            var vice = new Filme("tt3606756", "Os Incríveis 2", 2018, 8.5);
            //Act
            var resultadoCompeticao = competicao.CriarCompeticao();
            var resultadoCampeao = resultadoCompeticao["campeao"];
            var resultadoVice = resultadoCompeticao["vice"];

            //Assert

            Assert.Equal(campeao, resultadoCampeao);
            Assert.Equal(vice, resultadoVice);
        }

    }
}
