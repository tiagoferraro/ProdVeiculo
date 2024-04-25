using ProdVeiculo.Api.ValidationAtr;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ProdVeiculo.Application.DTOs
{
    public class FornecedorDTO
    {
        [IgnoreDataMember]
        public int? Codigo { get; set; }
        public DateTime? DataCadastro { get; set; }
        [Required(ErrorMessage = "Descrição é obrigatório")]  
        public String Descricao { get; set; }
        [Required(ErrorMessage = "O CNPJ é Obrigatório")]
        [ValidaCnpjAtributte]
        [RegularExpression("([0-9]+)",ErrorMessage ="CNPJ deve conter apenas numeros")]
        public string Cnpj { get; set; }
    }
}
