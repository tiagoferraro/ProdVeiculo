using ProdVeiculo.Application.DTOs;
using ProdVeiculo.shared.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdVeiculo.Application.interfaces
{
    public interface IFornecedorService
    {
        Task<Resultado> ObterPorCodigo(int id);
        Task<Resultado> ObterPorCNPJ(string cnpj);
        Task<Resultado> ObterTodos();
        Task<Resultado> Adicionar(FornecedorDTO fornecedorDTO);
        Task<Resultado> Atualizar(FornecedorDTO fornecedorDTO);
    }
}
