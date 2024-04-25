using AutoMapper;
using ProdVeiculo.Application.DTOs;
using ProdVeiculo.Application.interfaces;
using ProdVeiculo.domain.entity;
using ProdVeiculo.domain.interfaces;
using ProdVeiculo.shared.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdVeiculo.Application.Services
{
    public class FornecedorService : IFornecedorService
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IMapper _mapper;

        public FornecedorService(IFornecedorRepository fornecedor, IMapper mapper)
        {
            _fornecedorRepository = fornecedor;
            _mapper = mapper;
        }

        public async Task<Resultado> Adicionar(FornecedorDTO fornecedorDTO)
        {
            var fornecedor = _mapper.Map<Fornecedor>(fornecedorDTO);

            if (await _fornecedorRepository.Existe(fornecedor))
            {
                return new Resultado(false, "Fornecedor já Existente");
            }

            var FornecedorAdicionado =  await _fornecedorRepository.Adicionar(fornecedor);
            return new Resultado(true, "", _mapper.Map<FornecedorDTO>(FornecedorAdicionado));
        }

        public async Task<Resultado> Atualizar(FornecedorDTO fornecedorDTO)
        {

            if (fornecedorDTO.Codigo is null || fornecedorDTO.Codigo <= 0 )
            {
                return new Resultado(false, "O Campo código é Obrigatório");
            }
         
            var fornecedor = _mapper.Map<Fornecedor>(fornecedorDTO);

            if (!await _fornecedorRepository.Existe(fornecedor))
            {
                return new Resultado(false, "O Fornecedor não existe");
            }

            await _fornecedorRepository.Atualizar(fornecedor);
            return new Resultado(true,"");
        }

        public async Task<Resultado> ObterPorCNPJ(string cnpj)
        {
            var fornecedor = await _fornecedorRepository.ObterPorCnpj(cnpj);
            if (fornecedor is null)
                return new Resultado(false, "Fornecedor não encontrado");
            return new Resultado(true, "", fornecedor);
        }

        public async Task<Resultado> ObterPorCodigo(int id)
        {
            var fornecedor = await _fornecedorRepository.ObterPorCodigo(id);
            return new Resultado(true, "", _mapper.Map<FornecedorDTO>(fornecedor));
        }

        public async Task<Resultado> ObterTodos()
        {
            var lista = await _fornecedorRepository.ObterTodos();
            return new Resultado(true, "", _mapper.Map<IEnumerable<FornecedorDTO>>(lista));
        }
    }
}
