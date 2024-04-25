using AutoMapper;
using ProdVeiculo.Application.DTOs;
using ProdVeiculo.domain.entity;
using ProdVeiculo.domain.entity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdVeiculo.Application.Mappings
{
    public class ProdutoMapingProfile : Profile
    {
        public ProdutoMapingProfile()
        {
            CreateMap<Produto, ProdutoDTO>()   
           .ForMember(d => d.CodigoFornecedor, o => o.MapFrom(s => s.FornecedorId));

            CreateMap<ProdutoDTO, Produto>().ConstructUsing(x => new Produto(x.descricao, (SituacaoProduto)x.situacao,x.DataFabricacao,x.DataValidade,x.CodigoFornecedor ));
         


        }
    }
}
