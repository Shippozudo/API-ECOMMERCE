using Exercicio02_API_Ecomerce.Enumeradores;
using System;

namespace Exercicio02_API_Ecomerce.Entidades
{
    public class Credito :Pagamento
    {
        public Credito(Guid id, 
                      string titular,
                       string numero,
                       string cVV,
                       decimal limite,
                       DateTime validade) : base(id)
        {
            Titular = titular;
            Numero = numero;
            CVV = cVV;
            Limite = limite;
            Validade = validade;
            FormaPagamento = EformaPagamento.Credito;
        }

        public string Titular { get; private set; }
        public string Numero { get; private set; }
        public string CVV { get; private set; }
        public decimal Limite { get; private set; }
        public DateTime Validade { get; private set; }

        public override void Validar()
        {
            Valido = true;
        }
    }
}
