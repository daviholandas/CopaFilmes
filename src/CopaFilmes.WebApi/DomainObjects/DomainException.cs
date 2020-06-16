using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CopaFilmes.WebApi.DomainObjects
{
    public class DomainException : Exception
    {
        public DomainException(){}
        public DomainException(string message) : base(message){}
        public DomainException(string message, Exception innerException) : base(message, innerException){}
        
        
    }
}
