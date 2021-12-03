using Exercicio02_API_Ecomerce.DTOs;
using Exercicio02_API_Ecomerce.Entidades;
using Exercicio02_API_Ecomerce.Servicos;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Exercicio02_API_Ecomerce.Controllers
{
    [ApiController, Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoService _produtoService;
        public ProdutoController(ProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet, Route ("Retorna a lista de Produtos")]
        public IActionResult Get()
        {
            return Ok(_produtoService.Get());
        }

        [HttpGet, Route("{id} Insere ID retorna o Produto")]
        public IActionResult Get(Guid id)
        {
            return Ok(_produtoService.Get(id));
        }


        [HttpPost, Route("Cadastrar Produto")]
        public IActionResult Cadastrar(ProdutoDTO produtoDTO)
        {
            produtoDTO.Validar();

            if (!produtoDTO.Valido)
                return BadRequest("Produto informado Inválido!!");


            var guid = Guid.NewGuid();

            var prod = new Produto(
                id: guid,
                nome: produtoDTO.Nome,
                descricao: produtoDTO.Descricao,
                preco: produtoDTO.Preco);

            return Created("", _produtoService.Cadastrar(prod));
        }


        [HttpPut, Route("{id} atualizar Produto pelo ID")]
        public IActionResult Atualizar(Guid id, ProdutoDTO produtoDTO)
        {
            produtoDTO.Validar();

            if (!produtoDTO.Valido)
                return BadRequest("Produto informado inválido!!");

            var prod = new Produto(
                id: id,
                nome: produtoDTO.Nome,
                descricao: produtoDTO.Descricao,
                preco: produtoDTO.Preco);

            return Created(" ", _produtoService.Atualizar(id, prod));

        }

        [HttpDelete, Route("{id}Deleta Produto")]
        public IActionResult Deletar(Guid id)
        {
            _produtoService.Deletar(id);

            return Ok();
        }


    }
}
