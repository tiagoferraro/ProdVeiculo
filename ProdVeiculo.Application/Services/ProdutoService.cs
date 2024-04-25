using AutoMapper;
using ProdVeiculo.Application.DTOs;
using ProdVeiculo.Application.interfaces;
using ProdVeiculo.domain.entity;
using ProdVeiculo.domain.interfaces;
using ProdVeiculo.domain.Validation;
using ProdVeiculo.shared.interfaces;
using ProdVeiculo.shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProdVeiculo.Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IMapper _mapper;

        public ProdutoService(IProdutoRepository produto, IMapper mapper, IFornecedorRepository fornecedorRepository)
        {
            _produtoRepository = produto;
            _mapper = mapper;
            _fornecedorRepository = fornecedorRepository;
        }

        public async Task<Resultado> ObterPorCodigo(int id)
        {
            Produto produto = await _produtoRepository.ObterPorCodigo(id);
            return new Resultado(true, "", _mapper.Map<ProdutoDTO>(produto));
        }

        public async Task<Resultado> ObterTodos(int numeroPagina, int quantidadePorPagina)
        {
            var produtos = await _produtoRepository.ObterTodos(numeroPagina, quantidadePorPagina) ;
            
            var produtosDTO = _mapper.Map<IEnumerable<ProdutoDTO>>(produtos);
            return new Resultado(true, "", new CabecalhoPaginacao(numeroPagina, quantidadePorPagina, produtos.Total,produtos.TotalPaginas, produtosDTO));
        }
        public async Task<Resultado> Adicionar(ProdutoDTO produtoDTO)
        {

            try
            {
                var produto = _mapper.Map<Produto>(produtoDTO);

                if ((await _fornecedorRepository.ObterPorCodigo(produto.FornecedorId)) is null)
                {
                    return new Resultado(false, "Fornecedor não existe");
                }
                if(await _produtoRepository.Existe(produto))                
                {
                    return new Resultado(false, "Produto já Existente");
                }

                var produtoAdicionado = await _produtoRepository.Adicionar(produto);
                
                return new Resultado(true, "", _mapper.Map<ProdutoDTO>(produtoAdicionado));
            }
            catch
            (DomainException ex)
            {
                return new Resultado(false, ex.Message);
            }



        }

        public async Task<Resultado> Atualizar(ProdutoDTO produtoDTO)
        {
            try
            {
                if (produtoDTO.Codigo is null || produtoDTO.Codigo <= 0)
                {
                    return new Resultado(false, "O Campo código é Obrigatório");
                }


                

                var produto = _mapper.Map<Produto>(produtoDTO);

                
                if ((await _produtoRepository.ObterPorCodigo(produto.Codigo)) is null)
                {
                    return new Resultado(false, "Produto não existe");
                }

                if ((await _fornecedorRepository.ObterPorCodigo(produto.FornecedorId)) is null)
                {
                    return new Resultado(false, "Fornecedor não existe");
                }


                await _produtoRepository.Atualizar(produto);
                return new Resultado(true, "");
            }
            catch
            (DomainException ex)
            {
                return new Resultado(false, ex.Message);
            }
        }

        public async Task<Resultado> Excluir(ProdutoDTO produtoDTO)
        {
            var produto = _mapper.Map<Produto>(produtoDTO);
            produto.Excluir();
             await _produtoRepository.Atualizar(produto); 
            return new Resultado(true, "");
        }



    }
}
