using Exercicio02_API_Ecomerce.Enumeradores;
using System;

namespace Exercicio02_API_Ecomerce.Entidades
{
    public abstract class Pagamento : EntidadeBase
    {
        public Pagamento(Guid id) : base(id)
        {

        }

        public EformaPagamento FormaPagamento { get; protected set; }
        public decimal Valor { get; set; }
        public abstract void Validar();
        public bool Valido { get; set; }






    }
}
