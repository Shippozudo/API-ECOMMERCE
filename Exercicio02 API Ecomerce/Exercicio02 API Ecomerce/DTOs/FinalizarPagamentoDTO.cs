using Exercicio02_API_Ecomerce.Enumeradores;

namespace Exercicio02_API_Ecomerce.DTOs
{
    public class FinalizarPagamentoDTO : Validator
    {
        public EformaPagamento FormaPagamento { get; set; }
        public PedidoDTO? pedidoDTO { get; set; }
        public PixDTO? pixDTO { get; set; }
        public CreditoDTO? creditoDTO { get; set; }
        public DebitoDTO? debitoDTO { get; set; }
        public decimal Valor { get; set; }




        public override void Validar()
        {
            Valido = true;
            if (FormaPagamento == null)
                Valido = false;




        }
    }
}
