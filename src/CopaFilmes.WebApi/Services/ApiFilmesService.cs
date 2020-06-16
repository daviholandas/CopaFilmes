using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CopaFilmes.WebApi.Config;
using CopaFilmes.WebApi.DTOs;
using CopaFilmes.WebApi.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace CopaFilmes.WebApi.Services
{
    public class ApiFilmesService : IApiFilmesService
    {
        private readonly HttpClient _httpClient;
        private readonly IApiExternaConfig _apiExternaConfig;
        private ILogger<HttpClient> _logger;

        public ApiFilmesService(HttpClient httpClient,
            IApiExternaConfig apiExternaConfig)
        {
            _httpClient = httpClient;
            _apiExternaConfig = apiExternaConfig;
        }
        public async Task<IEnumerable<FilmeDto>> ObterFilmes()
        {
            IEnumerable<FilmeDto> filmes = new List<FilmeDto>(){};
            try
            {
                filmes = await  _httpClient.GetFromJsonAsync<IEnumerable<FilmeDto>>($"{_apiExternaConfig.BaseUrl}filmes");
            }
            catch (Exception e)
            {
               _logger.LogError(e.Message);
            }

            return filmes;
        }
    }
}
