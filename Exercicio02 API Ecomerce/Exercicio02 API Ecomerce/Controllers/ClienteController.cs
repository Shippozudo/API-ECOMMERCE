using Exercicio02_API_Ecomerce.DTOs;
using Exercicio02_API_Ecomerce.Entidades;
using Exercicio02_API_Ecomerce.Servicos;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Exercicio02_API_Ecomerce.Controllers
{

    [ApiController, Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService _clienteService;


        public ClienteController(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }



        [HttpGet, Route("Retorna a lista de Clientes")]
        public IActionResult Get()
        {
            return Ok(_clienteService.Get());
        }

        [HttpGet, Route("{id} Retorna cliente pelo ID")]
        public IActionResult Get(Guid id)
        {
            return Ok(_clienteService.Get(id));
        }

        [HttpPost, Route("Cadastra novo cliente")]
        public IActionResult Cadastrar(ClienteDTO clienteDTO)
        {
            clienteDTO.Validar();

            if (!clienteDTO.Valido)
                return BadRequest("Cliente invalido");

            var guid = Guid.NewGuid();

            var cli = new Cliente(
                id: guid,
                nome: clienteDTO.Nome,
                sobrenome: clienteDTO.Sobrenome,
                documento: clienteDTO.Documento,
                tipoPessoa: clienteDTO.TipoPessoa);

            return Created("", _clienteService.Cadastrar(cli));


        }

        [HttpPut, Route("{id} Atualizar cliente")]
        public IActionResult Atualizar(Guid id, ClienteDTO clienteDTO)
        {
            clienteDTO.Validar();

            if (!clienteDTO.Valido)
                return BadRequest("Cliente nao encontrado");

            var cli = new Cliente(
                id: id,
                nome: clienteDTO.Nome,
                sobrenome: clienteDTO.Sobrenome,
                documento: clienteDTO.Documento,
                tipoPessoa: clienteDTO.TipoPessoa
                );

            return Created("", _clienteService.Atualizar(id, cli));
        }

        [HttpDelete, Route("{id} Deleta cliente")]
        public IActionResult Deletar(Guid id)
        {
            _clienteService.Deletar(id);
            return Ok();
        }


    }

}
