using ProdVeiculo.domain.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdVeiculo.domain.interfaces
{
    public interface IFornecedorRepository
    {
        Task<Fornecedor> ObterPorCodigo(int id);
        Task<Fornecedor> ObterPorCnpj(string CNPJ);
        Task<Boolean> Existe(Fornecedor fornecedor);
        Task<IEnumerable<Fornecedor>> ObterTodos();
        Task<Fornecedor> Adicionar(Fornecedor fornecedor);
        Task Atualizar(Fornecedor fornecedor);
    }
}
