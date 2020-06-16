using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CopaFilmes.WebApi.DTOs
{
    public class FilmeDto
    {
        public string Id { get; set; }
        public string Titulo { get; set; }
        public int Ano { get; set; }
        public double Nota { get; set; }
    }
}
