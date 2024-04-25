using ProdVeiculo.domain.entity;
using ProdVeiculo.domain.entity.Enum;
using ProdVeiculo.domain.Validation;

namespace ProdVeiculo.Test.Domain
{
    public class ProdutoTest
    {
        [Fact(DisplayName = "Novo Produto - Valido")]
        public void Produto_NovoProduto_deveestarValido()
        {
            //Arrange
            var produto = new Produto("Peça numero 2",
                SituacaoProduto.Ativo,
                new DateTime(2024,2,6),
                new DateTime(2024, 4, 6),
                3
                );
            //Assert
            Assert.Equal(produto, produto);  
        }
        [Fact(DisplayName = "Novo Produto - Invalido")]
        public void Produto_NovoProduto_deveestarInvalido()
        {
            Assert.Throws<DomainException>(() => new Produto(String.Empty,
                SituacaoProduto.Ativo,
                new DateTime(2024, 2, 6),
                new DateTime(2024, 4, 6),
                3
                ));
        }
        [Fact(DisplayName = "Novo Produto - Invalido - Comparar Datas")]
        public void Produto_NovoProduto_deveestarInvalidoPorDataDeFabricacao()
        {
            Assert.Throws<DomainException>(() => new Produto("Peça de carro",
                SituacaoProduto.Ativo,
                new DateTime(2024, 5, 6),
                new DateTime(2024, 4, 6),
                3
                ));
        }
    }
}