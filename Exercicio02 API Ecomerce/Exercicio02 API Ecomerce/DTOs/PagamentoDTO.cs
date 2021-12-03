using Exercicio02_API_Ecomerce.Enumeradores;

namespace Exercicio02_API_Ecomerce.DTOs
{
    public class PagamentoDTO : Validator
    {
        public EformaPagamento FormaPagamento { get; set; }

        public override void Validar()
        {
            Valido = true;
            if (FormaPagamento == null)
                Valido = false;
            
        }

    }
}
