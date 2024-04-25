using Microsoft.EntityFrameworkCore;
using ProdVeiculo.domain.entity;
using ProdVeiculo.domain.interfaces;
using ProdVeiculo.Infra.Context;
using ProdVeiculo.Infra.helpers;
using ProdVeiculo.shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdVeiculo.Infra.Repositories
{

    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AppDbContext _context;

        public ProdutoRepository(AppDbContext context)
        {
            _context = context;
        }


        public async Task<Produto> Adicionar(Produto produto)
        {
            _context.Produto.Add(produto);
            await _context.SaveChangesAsync();
            return  produto;
            
        }

        public async Task Atualizar(Produto produto)
        {
            _context.Produto.Update(produto);
            await _context.SaveChangesAsync();
        }

        public Task<bool> Existe(Produto produto)
        {
            return _context.Produto.AnyAsync(p => p.FornecedorId == produto.FornecedorId && p.Descricao == produto.Descricao);
        }

        public async Task<Produto> ObterPorCodigo(int id)
        {
            var produto = await _context.Produto.Include(x => x.Fornecedor).AsNoTracking().FirstOrDefaultAsync(x => x.Codigo == id);
     
            if (produto != null)
            {                
                return produto ;
            }

            return null;
        }

        public async Task<PaginaList<Produto>> ObterTodos(int numeroPagina, int quantidadePorPagina)
        {
            var query = _context.Produto.Include(x => x.Fornecedor).AsNoTracking().OrderByDescending(x => x.Codigo).AsQueryable();
            return await PaginacaoHelper.CriarAsync(query, numeroPagina, quantidadePorPagina);
        }

     
    }
}
