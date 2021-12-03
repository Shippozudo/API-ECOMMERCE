using Exercicio02_API_Ecomerce.Enumeradores;
using System;

namespace Exercicio02_API_Ecomerce.Entidades
{
    public class Debito : Pagamento
    {
        public Debito(Guid id,
                      string titular,
                      string numero,
                      string cVV,
                      decimal saldo,
                      DateTime validade) : base(id)
        {
            Titular = titular;
            Numero = numero;
            CVV = cVV;
            Saldo = saldo;
            Validade = validade;
            FormaPagamento = EformaPagamento.Debito;
        }

        public string Titular { get; private set; }
        public string Numero { get; private set; }
        public string CVV { get; private set; }
        public decimal Saldo { get; private set; }
        public DateTime Validade { get; private set; }

        public override void Validar()
        {
            Valido = true;
        }
    }
}
