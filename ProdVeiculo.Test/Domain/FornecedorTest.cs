using ProdVeiculo.domain.entity.Enum;
using ProdVeiculo.domain.entity;
using ProdVeiculo.domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdVeiculo.Test.Domain
{
    public class FornecedorTest
    {
        [Fact(DisplayName = "Novo Fornecedor - Valido")]
        public void Produto_NovoProduto_deveestarValido()
        {
            //Arrange
            var fornecedor = new Fornecedor("Bosch", "66284913000195");
            //Assert
            Assert.Equal(fornecedor, fornecedor);
        }
        [Fact(DisplayName = "Novo Fornecedor - Invalido")]
        public void Produto_NovoProduto_deveestarInvalido()
        {
            Assert.Throws<DomainException>(() => new Fornecedor(string.Empty, "66284913000195"));
            Assert.Throws<DomainException>(() => new Fornecedor("Bosch", string.Empty));
        }
    
    
    }
}
