using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CopaFilmes.WebApi.Config
{
    public class ApiExternaConfig : IApiExternaConfig
    {
        public string BaseUrl { get; set; }
    }
}
