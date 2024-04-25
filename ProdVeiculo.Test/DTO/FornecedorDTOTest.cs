using ProdVeiculo.Application.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdVeiculo.Test.DTO
{
    public class FornecedorDTOtest
    {
        [Fact(DisplayName = "DTO Fornecedor - Valido")]
        public void Produto_NovoProduto_deveestarValido()
        {
            //Arrange
            var fornecedor = new FornecedorDTO();
            fornecedor.Cnpj = "Fornecedor";
            fornecedor.Descricao = "Bosch";

            //ACT

            var context = new ValidationContext(fornecedor, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(fornecedor, context, results);

            //Assert
            Assert.True(isValid);
        }


        public static TheoryData<string, string> CasesFornecedorDTO =
        new()
        {     
            { "","71934363000142" },
            { "Bosch","" },
        };

        [Theory(DisplayName = "DTO Fornecedor - Invalido"), MemberData(nameof(CasesFornecedorDTO))]
        public void Produto_NovoProduto_deveestarInvalido( string descricao, string cnpj)
        {
            //Arrange
            var fornecedor = new FornecedorDTO();
            fornecedor.Cnpj = cnpj;
            fornecedor.Descricao = descricao;

            //ACT

            var context = new ValidationContext(fornecedor);
            
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(fornecedor, context, results);

            //Assert
            Assert.True(!isValid);
        }
    }
}
