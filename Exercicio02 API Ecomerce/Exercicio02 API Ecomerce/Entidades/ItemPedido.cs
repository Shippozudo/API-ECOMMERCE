using System;

namespace Exercicio02_API_Ecomerce.Entidades
{
    public class ItemPedido : EntidadeBase
    {
        public ItemPedido(Guid id,Produto produto, decimal quantidade) :base(id)
        {
            Produto = produto;
            Quantidade = quantidade;
            
        }

        public Produto Produto { get; set; }
        public decimal Quantidade { get; set; }
       
    }
}
