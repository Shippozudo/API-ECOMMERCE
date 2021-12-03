using Exercicio02_API_Ecomerce.Enumeradores;
using System;

namespace Exercicio02_API_Ecomerce.DTOs
{
    public class ClienteDTO : Validator
    {
        public Guid? Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Documento { get; set; }
        public EtipoPessoa TipoPessoa { get; set; }
        public PedidoDTO? Pedido { get; set; }
        

        public override void Validar()
        {
            Valido = true;
            if (string.IsNullOrEmpty(Nome) || Nome.Length > 150)
                Valido = false;
            if (string.IsNullOrEmpty(Sobrenome) || Sobrenome.Length > 150)
                Valido = false;
            if (string.IsNullOrEmpty(Documento))
                Valido = false;
            if (TipoPessoa == EtipoPessoa.Fisica)
                Valido = ValidarCpf(Documento);
            if (TipoPessoa == EtipoPessoa.Juridica)
                Valido = ValidarCnpj(Documento);

        }
        private bool ValidarCpf(string cpf)
        {
            return true;
        }
        private bool ValidarCnpj(string cnpj)
        {
            return true;
        }


    }
}
