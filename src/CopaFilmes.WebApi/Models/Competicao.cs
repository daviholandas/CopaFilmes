using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CopaFilmes.WebApi.DomainObjects;

namespace CopaFilmes.WebApi.Models
{
    public class Competicao
    {
        private const int NUMERO_COMPETIDORES = 8;
        private IDictionary<int, Partida> _chaveamento =  new Dictionary<int, Partida>();
        private IDictionary<int, Partida> _chaveamentoQuartas = new Dictionary<int, Partida>();
        private IList<Filme> _resultadoFinal = new List<Filme>();
        public IEnumerable<Filme> Competidores { get; private set; }
        public Competicao(IEnumerable<Filme> competidores)
        {
            Competidores = competidores;
        }
        
        private Competicao(){}
        
        private IDictionary<int, Partida> CriarChaveamento()
        {
            var key = 1;
            var indexInicial = NUMERO_COMPETIDORES;
            var quantidadeDeChaves = Competidores.Count() / 2;
            
            for (int i = 0; i < quantidadeDeChaves ; i++)
            {
               _chaveamento.Add(key++, new Partida(Competidores.ElementAt(i), Competidores.ElementAt(--indexInicial)));
            }

            return _chaveamento;
        }

        public void DisputarCompeticao()
        {
            CriarChaveamento();
            DisputarQuartas();
            DisputarFinal();
        }
        
        private void DisputarQuartas()
        {
            var key = 1;
            
            for (int i = 1; i <= _chaveamento.Count(); i+=2)
            {
                _chaveamentoQuartas.Add(key++, new Partida(_chaveamento[i].EscolherVencedor(), _chaveamento[i+1].EscolherVencedor()));
            }
        }
        
        private void DisputarFinal()
        {
            
            for (int i = 0; i < _chaveamentoQuartas.Count(); i++)
            {
                _resultadoFinal.Add(_chaveamentoQuartas[i + 1].EscolherVencedor());
            }
        }

        public IDictionary<int, Partida> ObterChaveamento()
            => CriarChaveamento();

        public IDictionary<string, Filme> ObterCampeaoEVice()
        {
            var campeao = new Partida(_resultadoFinal[0], _resultadoFinal[1]).EscolherVencedor();
            var vice = _resultadoFinal.First(f => f != campeao);
            
            return new Dictionary<string, Filme>()
            {
                {"campeao", campeao},
                {"vice", vice}
            };
        }
    }
}