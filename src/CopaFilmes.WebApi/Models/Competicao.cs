using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CopaFilmes.WebApi.Models
{
    public class Competicao
    {
        public IEnumerable<Filme> Competidores { get; private set; }
        
        public Competicao(IEnumerable<Filme> competidores)
        {
            Competidores = competidores;
        }
        private Competicao(){}


        public IDictionary<int, Partida> CriarChaveamento()
        {
            var key = 1;
            var tamanho = Competidores.Count();
            var chaveamento = new Dictionary<int, Partida>(){};
            for (int i = 0; i < 4 ; i++)
            {
                chaveamento.Add(key++, new Partida(Competidores.ElementAt(i), Competidores.ElementAt(--tamanho)));
            }

            return chaveamento;
        }

        public IDictionary<int, Partida> DisputarQuartas(IDictionary<int, Partida> chavemanto)
        {
            
            var quartas = new Dictionary<int, Partida>(){};
            var key = 1;
            for (int i = 1; i <= chavemanto.Count(); i+=2)
            {
                quartas.Add(key++, new Partida(chavemanto[i].EscolherVencedor(), chavemanto[i+1].EscolherVencedor()));
            }

            return quartas;
        }

        public IList<Filme> DisputarFinal(IDictionary<int, Partida> quartas)
        {
            var final = new List<Filme>(){};
            for (int i = 0; i < quartas.Count(); i++)
            {
                final.Add(quartas[i + 1].EscolherVencedor());
            }

            return final;
        }

        public IDictionary<string, Filme> CriarCompeticao()
        {
            var chaveamento = CriarChaveamento();
            var quartas = DisputarQuartas(chaveamento);
            var final = DisputarFinal(quartas);

            
            var campeao = new Partida(final[0], final[1]).EscolherVencedor();
            var vice = final.First(f => f != campeao);
            
            return new Dictionary<string, Filme>()
            {
                {"campeao", campeao},
                {"vice", vice}
            };
        }
    }
}