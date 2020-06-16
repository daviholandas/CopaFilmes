using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CopaFilmes.WebApi.Models
{
    public class Partida
    {
        public Filme Competidor1 { get; private set; }
        public Filme Competidor2 { get; private set; }

        public Partida(Filme competidor1, Filme competidor2)
        {
            Competidor1 = competidor1;
            Competidor2 = competidor2;
        }

        private Partida(){}

        public Filme EscolherVencedor()
        {

            if (Competidor1 == Competidor2 || Competidor1.Nota > Competidor2.Nota)
                return Competidor1;

            if (Competidor1.Nota == Competidor2.Nota
                && String.Compare(Competidor1.Titulo, Competidor2.Titulo) < 0)
                return Competidor1;
            
            return Competidor2;
        }

        
    }
}
