using AutoMapper;
using Moq;
using ProdVeiculo.Application.Mappings;
using ProdVeiculo.Application.Services;
using ProdVeiculo.domain.entity;
using ProdVeiculo.domain.interfaces;
using ProdVeiculo.Test.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdVeiculo.Test.Service
{
    [Collection(nameof(ProdutoBogusCollection))]
    public class ProdutoServiceTest
    {
        readonly ProdutosBogusFixture _clienteTestsBogus;

        readonly IMapper _mapper;

        public ProdutoServiceTest(ProdutosBogusFixture clienteTestsBogus)
        {
            _clienteTestsBogus = clienteTestsBogus;

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new FornecedorMapingProfile());
                cfg.AddProfile(new ProdutoMapingProfile());
            });
            _mapper = mockMapper.CreateMapper();
        }

        [Fact(DisplayName = "Produto Service Adicionar - Sucesso")]
        public async Task ProdutoService_Adicionar_DeveExecutarComSucessoAsync()
        {
            // Arrange
            var produtoDTO = _clienteTestsBogus.GerarProdutoValido();
            var produtoRepo = new Mock<IProdutoRepository>();
            var fornecedorRepo = new Mock<IFornecedorRepository>();

            fornecedorRepo.Setup(c => c.ObterPorCodigo(produtoDTO.CodigoFornecedor))
                    .Returns(Task.FromResult(new Fornecedor("fornecededor","142451452414")));

            var produtoService = new ProdutoService(produtoRepo.Object,_mapper,fornecedorRepo.Object);

            // Act
            var resultado = await produtoService.Adicionar(produtoDTO);

            // Assert            
                Assert.True(resultado.Success);            
        }
        [Fact(DisplayName = "Produto Service Adicionar - Insucesso - Fornecedor não existe")]
        public async Task ProdutoService_Adicionar_DeveExecutarComInsucessoFornecedorAsync()
        {
            // Arrange
            var produtoDTO = _clienteTestsBogus.GerarProdutoValido();
            var produtoRepo = new Mock<IProdutoRepository>();
            var fornecedorRepo = new Mock<IFornecedorRepository>();


            var produtoService = new ProdutoService(produtoRepo.Object, _mapper, fornecedorRepo.Object);

            // Act
            var resultado = await produtoService.Adicionar(produtoDTO);

            // Assert            
            Assert.True(!resultado.Success);
        }
        [Fact(DisplayName = "Produto Service Atualizar - Sucesso")]
        public async Task ProdutoService_Atualizar_DeveExecutarComInsucessoFornecedorAsync()
        {
            // Arrange
            var produtoDTO = _clienteTestsBogus.GerarProdutoValido();
            var produtoRepo = new Mock<IProdutoRepository>();
            var fornecedorRepo = new Mock<IFornecedorRepository>();

            var produtoService = new ProdutoService(produtoRepo.Object, _mapper, fornecedorRepo.Object);
            fornecedorRepo.Setup(c => c.ObterPorCodigo(produtoDTO.CodigoFornecedor))
               .Returns(Task.FromResult(new Fornecedor("fornecededor", "142451452414")));
            produtoRepo.Setup(c => c.ObterPorCodigo(produtoDTO.Codigo.Value))
                .Returns(Task.FromResult(_mapper.Map<Produto>(produtoDTO)));
            // Act
            var resultado = await produtoService.Atualizar(produtoDTO);

            // Assert            
            Assert.True(resultado.Success);
        }
        [Fact(DisplayName = "Produto Service Excluir - Sucesso")]
        public async Task ProdutoService_Excluir_DeveExecutarComSucessoAsync()
        {
            // Arrange
            var produtoDTO = _clienteTestsBogus.GerarProdutoValido();
            var produtoRepo = new Mock<IProdutoRepository>();
            var fornecedorRepo = new Mock<IFornecedorRepository>();


            var produtoService = new ProdutoService(produtoRepo.Object, _mapper, fornecedorRepo.Object);

            // Act
            var resultado = await produtoService.Excluir(produtoDTO);

            // Assert            
            Assert.True(resultado.Success);
        }

    }
}
