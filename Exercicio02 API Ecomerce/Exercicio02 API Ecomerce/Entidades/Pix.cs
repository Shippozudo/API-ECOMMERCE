using Exercicio02_API_Ecomerce.Enumeradores;
using System;

namespace Exercicio02_API_Ecomerce.Entidades
{
    public class Pix : Pagamento
    {
        public Pix(Guid id, string agencia,
                   string nomeTitular,
                   string numeroConta,
                   string instituicao,
                   ETipoChavePix chavePix) : base(id)
        {
            Agencia = agencia;
            NomeTitular = nomeTitular;
            NumeroConta = numeroConta;
            Instituicao = instituicao;
            ChavePix = chavePix;
            FormaPagamento = EformaPagamento.Pix;

        }


        public string Agencia { get; set; }
        public string NomeTitular { get; set; }
        public string NumeroConta { get; set; }
        public string Instituicao { get; set; }
        public ETipoChavePix ChavePix { get; set; }

        public override void Validar()
        {
            Valido = true;
            
        }
    }
}
