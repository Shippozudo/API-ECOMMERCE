using Exercicio02_API_Ecomerce.Entidades;
using System;

namespace Exercicio02_API_Ecomerce.DTOs
{
    public class ItemPedidoDTO : Validator
    {

       
        public ProdutoDTO Produto { get; set; }
        public decimal Quantidade { get; set; }
       


        public override void Validar()
        {

            Valido = true;
           
            if (Quantidade <= 0)
                Valido = false;

        }
    }
}
