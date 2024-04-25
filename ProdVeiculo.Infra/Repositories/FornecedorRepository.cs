using Microsoft.EntityFrameworkCore;
using ProdVeiculo.domain.entity;
using ProdVeiculo.domain.interfaces;
using ProdVeiculo.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdVeiculo.Infra.Repositories
{
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly AppDbContext _context;

        public FornecedorRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Fornecedor> Adicionar(Fornecedor fornecedor)
        {
            _context.Fornecedor.Add(fornecedor);
            await _context.SaveChangesAsync();
            return fornecedor;
        }

        public async Task Atualizar(Fornecedor fornecedor)
        {
            _context.Fornecedor.Update(fornecedor);
            await _context.SaveChangesAsync();         
        }

        public async Task<Fornecedor> ObterPorCnpj(string Cnpj)
        {
            return await _context.Fornecedor.FirstOrDefaultAsync(f => f.Cnpj == Cnpj);
        }

        public async Task<Fornecedor> ObterPorCodigo(int id)
        {
            return await _context.Fornecedor.FindAsync(id);
        }

        public async Task<IEnumerable<Fornecedor>> ObterTodos()
        {
            return await _context.Fornecedor.AsNoTracking().ToListAsync();
        }
        public Task<Boolean> Existe(Fornecedor fornecedor)
        {
            return _context.Fornecedor.AnyAsync(p => p.Cnpj == fornecedor.Cnpj);
        }
    }
}
