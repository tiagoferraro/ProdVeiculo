using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdVeiculo.shared.Model
{
    public class ErroResult
    {

        public String Mensagem {  get; private set; }

        public ErroResult(string mensagem)
        {
            Mensagem = mensagem;
            Erros = new List<string>();
        }

        public List<String> Erros { get; set; }

        
    }
}
