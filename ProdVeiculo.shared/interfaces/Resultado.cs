using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdVeiculo.shared.interfaces
{

    public class Resultado 
    {
        public bool Success { get; private set; }
        public string Message { get; private set; }
        public object Dados { get;private set; }
        
        public Resultado(bool success, string message, object dados)
        {
            Success = success;
            Message = message;       
            Dados = dados;
        }
        public Resultado(bool success, string message)
        {
            Success = success;
            Message = message;            
        }


    }
}
