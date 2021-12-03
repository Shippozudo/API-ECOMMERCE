namespace Exercicio02_API_Ecomerce.DTOs
{
    public abstract class Validator
    {
        public bool Valido { get; protected set; }
        public abstract void Validar();
        
    }
}
