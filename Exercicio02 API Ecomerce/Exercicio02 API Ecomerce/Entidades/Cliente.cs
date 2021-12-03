using Exercicio02_API_Ecomerce.Enumeradores;
using System;

namespace Exercicio02_API_Ecomerce.Entidades
{
    public class Cliente : EntidadeBase
    {

        public Cliente(Guid id,
            string nome,
            string sobrenome,
            string documento,
            EtipoPessoa tipoPessoa) : base(id)
        {

            Nome = nome;
            Sobrenome = sobrenome;
            Documento = documento;
            TipoPessoa = tipoPessoa;
            

            CriarPedido();
        }

        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Documento { get; set; }
        public EtipoPessoa TipoPessoa { get; set; }
        public Pedido? Pedido { get; set; }
       


        public void CriarPedido()
        {
            Pedido = new Pedido(Guid.NewGuid(), this);

        }

        public void Atualizar(Cliente cliente)
        {
            Nome = cliente.Nome;
            Sobrenome = cliente.Sobrenome;
            Documento = cliente.Documento;
            TipoPessoa = cliente.TipoPessoa;

        }

      











    }

}
