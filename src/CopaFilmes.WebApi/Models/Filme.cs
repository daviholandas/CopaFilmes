using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CopaFilmes.WebApi.DomainObjects;

namespace CopaFilmes.WebApi.Models
{
    public class Filme
    {
        public string Id { get; private set; }
        public string Titulo { get; private set; }
        public int Ano { get; private set; }
        public double Nota { get; private set; }

        public Filme(string id, string titulo, int ano, double nota)
        {
            Id = id;
            Titulo = titulo;
            Ano = ano;
            Nota = nota;
            ValidacaoDeDominio();
        }

        private Filme(){}

        public override bool Equals(object obj)
        {
            var compareTo = obj as Filme;

            if (ReferenceEquals(null, compareTo)) return false;
            if (ReferenceEquals(this, compareTo)) return true;

            return Id.Equals(compareTo.Id);

        }


        public static bool operator ==(Filme a, Filme b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Filme a, Filme b)
            => !(a == b);

        public override int GetHashCode()
            => (GetType().GetHashCode() * 980) + Id.GetHashCode();

        public void ValidacaoDeDominio()
        {
            if(String.IsNullOrEmpty(Id))
                throw new DomainException("Id não pode ser nulo ou está em branco.");
            if (String.IsNullOrEmpty(Titulo))
                throw new DomainException("Titulo do filme não poder ser nulo ou está em branco.");
        }
    }
}
