using Microsoft.AspNetCore.Mvc;
using ProdVeiculo.Application.DTOs;
using ProdVeiculo.Application.interfaces;

using ProdVeiculo.shared.interfaces;
using ProdVeiculo.shared.Model;

namespace ProdVeiculo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorService _fornecedorService;

        public FornecedorController(IFornecedorService fornecedorService)
        {
            _fornecedorService = fornecedorService;
        }
        [HttpGet]
        public async Task<ActionResult> ObterTodos()
        {
            var resultado = await _fornecedorService.ObterTodos();
            return resultado.Success ? Ok(resultado.Dados) : NotFound(new ErroResult("Produto não encontrado"));
        }

        [HttpGet("{codigo}")]
        public async Task<ActionResult> ObterPorCodigo(int codigo)
        {
            var resultado = await _fornecedorService.ObterPorCodigo(codigo) ;
            return resultado.Success ? Ok(resultado.Dados) : NotFound(new ErroResult("Produto não encontrado"));
        }
     
        [HttpPost]
        public async Task<ActionResult> Cadastrar(FornecedorDTO fornecedor)
        {
            var resultado = await _fornecedorService.Adicionar(fornecedor);

            return resultado.Success ? Ok(resultado.Dados) : BadRequest(new ErroResult(resultado.Message));
        }
        [HttpPut]
        public async Task<ActionResult> Atualizar(FornecedorDTO fornecedor)
        {
            var resultado = await _fornecedorService.Atualizar(fornecedor) ;
            return resultado.Success ? Ok() : BadRequest(new ErroResult(resultado.Message));
        }


    }
}
