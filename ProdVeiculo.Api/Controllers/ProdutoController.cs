using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using ProdVeiculo.Application.DTOs;
using ProdVeiculo.Application.interfaces;
using ProdVeiculo.shared.interfaces;
using ProdVeiculo.shared.Model;

namespace ProdVeiculo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }
        [HttpGet("lista/{numeroPagina}/{quantidadePorPagina}")]
        public async Task<ActionResult> ObterTodos(int numeroPagina, int quantidadePorPagina)
        {
            var resultado = await _produtoService.ObterTodos(numeroPagina,quantidadePorPagina) ;

            if (resultado is null)
                return NotFound("Produto não encontrado");

            return Ok(resultado.Dados);
        }
        [HttpGet("{codigo}")]
        public async Task<ActionResult> ObterPorCodigo(int codigo)
        {
            var resultado = await _produtoService.ObterPorCodigo(codigo) ;
            if (resultado is null) 
                return NotFound("Produto não encontrado");
           
            return Ok(resultado.Dados);            
        }
        [HttpPost]
        public async Task<ActionResult> Adicionar(ProdutoDTO produtoDTO)
        {      
            

            var resulado = await _produtoService.Adicionar(produtoDTO) ;

            return resulado.Success ? Ok(resulado.Dados) : BadRequest(new ErroResult(resulado.Message));        
        }

        [HttpPut]
        public async Task<ActionResult> Alterar(ProdutoDTO produtoDTO)
        {

            var resulado = await _produtoService.Atualizar(produtoDTO);

            return resulado.Success ? Ok() : BadRequest(new ErroResult(resulado.Message));
        }
        [HttpDelete]
        public async Task<ActionResult> Excluir(ProdutoDTO produtoDTO)
        {

            var resulado = await _produtoService.Excluir(produtoDTO);

            return resulado.Success ? Ok() : BadRequest(new ErroResult(resulado.Message));
        }

    }
}
