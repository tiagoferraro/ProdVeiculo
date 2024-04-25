using ProdVeiculo.domain.Entities.Base;
using ProdVeiculo.domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProdVeiculo.domain.entity
{
    public class Fornecedor : Entity
    {
        public Fornecedor( string descricao,string cnpj)
        {            
            Descricao = descricao;
            Cnpj = cnpj;
            Validar();
        }

        public string Descricao { get; private set; }
        public string Cnpj { get; private set; }

        public ICollection<Produto> Produtos { get; set; }

        public void Validar()
        {
            Validacoes.ValidarSeVazio(Descricao, "O Campo Descricao do produto não pode ser vazio");
            Validacoes.ValidarSeVazio(Cnpj,  "O Campo CNPJ não pode ser vazio");
        }

    }
}
