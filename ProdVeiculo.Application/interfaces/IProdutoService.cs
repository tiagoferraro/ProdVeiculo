using ProdVeiculo.Application.DTOs;
using ProdVeiculo.domain.entity;
using ProdVeiculo.shared.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdVeiculo.Application.interfaces
{
    public interface IProdutoService
    {
        Task<Resultado> ObterPorCodigo(int id);
        Task<Resultado> ObterTodos(int numeroPagina, int quantidadePorPagina);
        Task<Resultado> Adicionar(ProdutoDTO produtoDTO);
        Task<Resultado> Atualizar(ProdutoDTO produtoDTO);
        Task<Resultado> Excluir(ProdutoDTO produtoDTO);
    }
}
