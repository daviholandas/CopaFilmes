using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CopaFilmes.WebApi.Config
{
    public interface IApiExternaConfig
    {
        string BaseUrl { get; set; }
    }

}
