using Bogus.DataSets;
using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProdVeiculo.domain.entity;
using ProdVeiculo.domain.entity.Enum;
using ProdVeiculo.Application.DTOs;

namespace ProdVeiculo.Test.Features
{
    [CollectionDefinition(nameof(ProdutoBogusCollection))]
    public class ProdutoBogusCollection : ICollectionFixture<ProdutosBogusFixture>
    { }
    public class ProdutosBogusFixture : IDisposable
    {
        public ProdutoDTO GerarProdutoValido()
        {
            return GerarProduto(1).FirstOrDefault();
        }

        public IEnumerable<ProdutoDTO> GerarProduto(int quantidade)
        {

            var produtos = new Faker<ProdutoDTO>("pt_BR")
                .CustomInstantiator(f => new ProdutoDTO(
                    1,
                    DateTime.Now,
                    f.Commerce.ProductDescription(),
                    (int)SituacaoProduto.Ativo,
                    new DateTime(),
                    new DateTime().AddDays(2),
                    1
                    ));
                
            return produtos.Generate(quantidade);
        }
        public void Dispose()
        {   


        }
    }
}
