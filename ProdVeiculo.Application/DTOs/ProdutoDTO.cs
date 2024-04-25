using ProdVeiculo.Api.ValidationAtr;
using ProdVeiculo.domain.entity;
using ProdVeiculo.domain.entity.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ProdVeiculo.Application.DTOs
{
    public class ProdutoDTO : IValidatableObject
    {
       
        public int? Codigo { get; set; }
        public DateTime? DataCadastro { get; set; }
        [Required(ErrorMessage = "Descrição do Produto é Obrigatório")]        
        public string descricao { get; set; }
        [Required(ErrorMessage = "Situação é Obrigatório")]
        public int? situacao { get; set; }        
        [Required(ErrorMessage = "Data de Fabricação é Obrigatória")]
        public DateTime DataFabricacao { get; set; }
        [Required(ErrorMessage = "Data de Validade é Obrigatória")]
        public DateTime DataValidade { get; set; }

      

        [Required(ErrorMessage = "O Codigo do Fornecedor é Obrigatório")]        
        public int CodigoFornecedor  { get; set; }

        
        public FornecedorDTO? Fornecedor { get; set; }


        public ProdutoDTO()
        {
            
        }
        public ProdutoDTO(int? codigo, DateTime? dataCadastro, string descricao, int? situacao, DateTime dataFabricacao, DateTime dataValidade, int codigoFornecedor)
        {
            Codigo = codigo;
            DataCadastro = dataCadastro;
            this.descricao = descricao;
            this.situacao = situacao;
            DataFabricacao = dataFabricacao;
            DataValidade = dataValidade;
            CodigoFornecedor = codigoFornecedor;
        }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DataFabricacao >= DataValidade)
            {
                yield return new ValidationResult("Data de Fabricação maior ou igual que a data de validade", new[] { "Data de Validade" });
            }
        }
    }
}
