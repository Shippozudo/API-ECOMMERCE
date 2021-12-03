using System;

namespace Exercicio02_API_Ecomerce.Entidades
{
    public class Produto : EntidadeBase
    {
        public Produto(Guid id,
                       string nome,
                       string descricao,
                       decimal preco) : base(id)
        {
            Nome = nome;
            Preco = preco;
            Descricao = descricao;
            

        }

        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        




        public void Atualizar(Produto produto)
        {
            Nome = produto.Nome;
            Descricao = produto.Descricao;
            Preco = produto.Preco;
            
        }



    }

}
