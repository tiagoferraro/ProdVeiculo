using ProdVeiculo.domain.entity.Enum;
using ProdVeiculo.domain.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProdVeiculo.Application.DTOs;
using System.ComponentModel.DataAnnotations;

namespace ProdVeiculo.Test.DTO
{
    public class ProdutoDTOTest
    {
        [Fact(DisplayName = "DTO Produto - Valido")]
        public void Produto_NovoProduto_deveestarValido()
        {
            //Arrange
            var produto = new ProdutoDTO(1,new DateTime(), "Volante",1, DateTime.Now, DateTime.Now.AddDays(2),2);            

            //ACT

            var context = new ValidationContext(produto, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(produto, context, results);

            //Assert
            Assert.True(isValid);
        }

        public static TheoryData<string, int?,DateTime, DateTime, int> Cases =
        new()
        {
        { "",1,DateTime.Now,DateTime.Now.AddDays(2),1 },      
        { "Volante",null, new DateTime(2024,4,4,1,1,1,1),  new DateTime(2024,4,4,1,1,1,1) ,1 },   
        { "Volante",1,DateTime.Now.AddDays(2) , DateTime.Now,1 },
        { "Volante",null,DateTime.Now, DateTime.Now.AddDays(2),0 },
        };

        [Theory(DisplayName = "DTO Produto - Invalido"),MemberData(nameof(Cases))]
  
     
        public void Produto_NovoProduto_deveestarInValido(String descricao,int? situacao,DateTime dataFabricacao,DateTime dataValidade, int codigoFornecedor )
        {
            //Arrange
            var produto = new ProdutoDTO(1,DateTime.Now,descricao,situacao,dataFabricacao,dataValidade,codigoFornecedor);                

            //ACT
            
            var context = new ValidationContext(produto, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(produto, context, results);            

            //Assert
            Assert.True(!isValid);
        }
     
 
    }
}
