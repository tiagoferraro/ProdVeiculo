using ProdVeiculo.domain.Entities.Base;
using ProdVeiculo.domain.entity.Enum;
using ProdVeiculo.domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdVeiculo.domain.entity
{
    public class Produto:Entity
    {
        public int FornecedorId { get; private set; }
        public string Descricao { get; private set; }
        public SituacaoProduto Situacao  { get; private set; }
        public DateTime DataFabricacao { get; private set; }

        public DateTime DataValidade { get; private set; }        

         
        public Fornecedor Fornecedor { get; set; }

      
        public Produto(String descricao,SituacaoProduto situacao, DateTime dataFabricacao,DateTime dataValidade,int fornecedorId) {

            Descricao = descricao;
            Situacao = situacao;
            DataFabricacao = dataFabricacao;
            DataValidade = dataValidade;
            FornecedorId = fornecedorId;
            Validar();
        }
        public void Excluir()
        {
            Situacao = SituacaoProduto.Inativo; 
        }

        public void Validar()
        {            
            Validacoes.ValidarSeVazio(Descricao, "O Campo Descricao do produto não pode ser vazio");
            Validacoes.ValidarSeMenorQue(DataValidade,DataFabricacao,  "A data de Fabricação não pode ser maior que a data de Validade");
        }

        

    }
}
