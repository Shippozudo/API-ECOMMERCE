using Exercicio02_API_Ecomerce.Entidades;
using Exercicio02_API_Ecomerce.Enumeradores;
using System;
using System.Collections.Generic;

namespace Exercicio02_API_Ecomerce.DTOs
{
    public class PedidoDTO : Validator
    {

        public Guid? Id { get; set; }
        public decimal Total { get; set; }
        public ClienteDTO ClienteDTO { get; set; }
        public List<ItemPedidoDTO>? ListaItemDTO { get; set; }
        public EformaPagamento? FormaPagamento { get; set; }

        public override void Validar()
        {
            Valido = true;

            if (Total <= 0)
                Valido = false;
            if (FormaPagamento == null)
                Valido = false;

        }
    }
}
