using AutoMapper;
using ProdVeiculo.Application.DTOs;
using ProdVeiculo.domain.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdVeiculo.Application.Mappings
{
    public class FornecedorMapingProfile : Profile
    {
        public FornecedorMapingProfile()
        {
            CreateMap<Fornecedor, FornecedorDTO>();
            CreateMap<FornecedorDTO, Fornecedor>();
        }
       
    }
}
