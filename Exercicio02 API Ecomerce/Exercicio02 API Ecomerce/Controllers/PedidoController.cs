using Exercicio02_API_Ecomerce.DTOs;
using Exercicio02_API_Ecomerce.Entidades;
using Exercicio02_API_Ecomerce.Enumeradores;
using Exercicio02_API_Ecomerce.Servicos;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Exercicio02_API_Ecomerce.Controllers
{
    [ApiController, Route("[controller]")]
    public class PedidoController : ControllerBase
    {

        private readonly PedidoService _pedidoService;
        public PedidoController(PedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }



        [HttpGet, Route("Retorna a lista de Pedidos")]
        public IActionResult Get()
        {
            return Ok(_pedidoService.Get());
        }



        [HttpGet, Route("{id} Retorna pedido pelo ID")]
        public IActionResult Get(Guid id)
        {
            return Ok(_pedidoService.Get(id));
        }

        //adiciona produto

        [HttpPost, Route("Cadastrar Pedido")]
        public IActionResult CadastrarPedido(PedidoDTO pedidoDTO)
        {
            pedidoDTO.Validar();
            if (!pedidoDTO.Valido)
                return BadRequest("Pedido invalido");

            var guid = Guid.NewGuid();

            var pedido = new Pedido(
                id: guid,
                cliente: new Cliente(
                    id: pedidoDTO.ClienteDTO.Id.Value,
                    nome: pedidoDTO.ClienteDTO.Nome,
                    sobrenome: pedidoDTO.ClienteDTO.Sobrenome,
                    documento: pedidoDTO.ClienteDTO.Documento,
                    tipoPessoa: pedidoDTO.ClienteDTO.TipoPessoa));




            return Created("", _pedidoService.CadastrarPedido(pedido));
        }



        [HttpPost, Route("{id}/item Adiciona item ao pedido")]
        public IActionResult AdicionarItem(Guid id, ItemPedidoDTO itemPedidoDTO)
        {
            itemPedidoDTO.Validar();
            if (!itemPedidoDTO.Valido)
                return BadRequest("Item invalido");

            var guid = Guid.NewGuid();

            var item = new ItemPedido(
                id: guid,
                produto: new Produto(id: itemPedidoDTO.Produto.Id.Value,
                        nome: itemPedidoDTO.Produto.Nome,
                        descricao: itemPedidoDTO.Produto.Descricao,
                        preco: itemPedidoDTO.Produto.Preco),
                        quantidade: itemPedidoDTO.Quantidade);

            _pedidoService.AdicionarItem(id, item);
            return Ok(_pedidoService.Get(id));

        }

        [HttpDelete, Route("{id}/Pedido/{idItem}/Item")]
        public IActionResult DeletarItem(Guid id, Guid idItem)
        {
            if (id == null)
                return BadRequest("ID pedido Invalido");
            if (idItem == null)
                return BadRequest("IdItem invalido");

            var item = _pedidoService.DeletarItem(id, idItem);
            return Ok();
        }

        [HttpPost, Route("{idPedido}/FinalizarPedido")]
        public IActionResult FinalizarPedido(Guid idPedido, FinalizarPagamentoDTO finalizarPagamentoDTO)
        {
            finalizarPagamentoDTO.Validar();
            if (!finalizarPagamentoDTO.Valido)
                return BadRequest("Forma Pagamento invalida");

            var guid = Guid.NewGuid();
            var pedido = _pedidoService.Get(idPedido);

            if (finalizarPagamentoDTO.FormaPagamento == EformaPagamento.Pix)
            {

                var pagamentoPix = new Pix(
                    id: guid,
                    agencia: finalizarPagamentoDTO.pixDTO.Agencia,
                    nomeTitular: finalizarPagamentoDTO.pixDTO.NomeTitular,
                    numeroConta: finalizarPagamentoDTO.pixDTO.NumeroConta,
                    instituicao: finalizarPagamentoDTO.pixDTO.Instituicao,
                    chavePix: finalizarPagamentoDTO.pixDTO.ChavePix)
                { Valor = finalizarPagamentoDTO.Valor };

                pagamentoPix.Validar();
                if (pagamentoPix == null)
                    return BadRequest("pagamento invalido");

                return Ok(_pedidoService.FinalizarPedido(idPedido, pagamentoPix));
            }
            if (finalizarPagamentoDTO.FormaPagamento == EformaPagamento.Credito)
            {
                var pagamentoCredito = new Credito(
                    id: guid,
                    titular: finalizarPagamentoDTO.creditoDTO.Titular,
                    numero: finalizarPagamentoDTO.creditoDTO.Numero,
                    cVV: finalizarPagamentoDTO.creditoDTO.CVV,
                    limite: finalizarPagamentoDTO.creditoDTO.Limite,
                    validade: finalizarPagamentoDTO.creditoDTO.Validade)
                { Valor = finalizarPagamentoDTO.Valor };

                pagamentoCredito.Validar();
                if (pagamentoCredito == null)
                    return BadRequest("pagamento invalido");

                return Ok(_pedidoService.FinalizarPedido(idPedido, pagamentoCredito));
            }
            if (finalizarPagamentoDTO.FormaPagamento == EformaPagamento.Debito)
            {
                var pagamentoDebito = new Debito(
                    id: guid,
                    titular: finalizarPagamentoDTO.debitoDTO.Titular,
                    numero: finalizarPagamentoDTO.debitoDTO.Numero,
                    cVV: finalizarPagamentoDTO.debitoDTO.CVV,
                    saldo: finalizarPagamentoDTO.debitoDTO.Saldo,
                    validade: finalizarPagamentoDTO.debitoDTO.Validade)
                { Valor = finalizarPagamentoDTO.Valor };

                pagamentoDebito.Validar();
                if (pagamentoDebito == null)
                    return BadRequest("pagamento invalido");

                return Ok(_pedidoService.FinalizarPedido(idPedido, pagamentoDebito));
            }
            if (!finalizarPagamentoDTO.Valido)
                return BadRequest("Forma Pagamento invalida");

            return BadRequest();

        }



    }

}
