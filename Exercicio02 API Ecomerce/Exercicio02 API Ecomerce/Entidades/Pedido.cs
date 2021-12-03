using Exercicio02_API_Ecomerce.Enumeradores;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercicio02_API_Ecomerce.Entidades
{
    public class Pedido : EntidadeBase
    {
        public Pedido(Guid id, Cliente cliente) : base(id)
        {

            Cliente = cliente;
            ListaItemPedido = new List<ItemPedido>();


        }

        public decimal Total { get; set; }
        public Cliente Cliente { get; set; }
        public List<ItemPedido>? ListaItemPedido { get; set; }

        public Pagamento Pagamentos { get; set; }

        public void CalcularTotal()
        {


            decimal somaTotal = 0m;
            foreach (var item in ListaItemPedido)
            {
                somaTotal += item.Produto.Preco * item.Quantidade;


            }
            Total = somaTotal;

        }
        public void DeletarItem(Guid idItem)
        {


            ListaItemPedido.RemoveAll(i => i.Id == idItem);


        }

        public void FinalizarPedido(Pagamento pagamento)
        {
            Pagamentos = pagamento;
           


        }


    }
}
