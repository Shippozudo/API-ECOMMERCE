using System;

namespace Exercicio02_API_Ecomerce.Entidades
{
    public abstract class EntidadeBase
    {
        protected EntidadeBase(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; private set; }
    }
}
