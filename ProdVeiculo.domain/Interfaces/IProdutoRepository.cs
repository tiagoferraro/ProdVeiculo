using ProdVeiculo.domain.entity;
using ProdVeiculo.shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdVeiculo.domain.interfaces
{
   public interface IProdutoRepository
    {
        Task<Produto> ObterPorCodigo(int id);
        Task<PaginaList<Produto>> ObterTodos(int numeroPagina, int quantidadePorPagina);
        Task<Produto> Adicionar(Produto produto);
        Task Atualizar(Produto produto);
        Task<Boolean> Existe(Produto produto);
    }
}
