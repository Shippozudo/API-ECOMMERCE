using Exercicio02_API_Ecomerce.Enumeradores;

namespace Exercicio02_API_Ecomerce.DTOs
{
    public class PixDTO : Validator
    {

        public string Agencia { get; set; }
        public string NomeTitular { get; set; }
        public string NumeroConta { get; set; }
        public string Instituicao { get; set; }
        public ETipoChavePix ChavePix { get; set; }



        public override void Validar()
        {
            Valido = true;
            if (ChavePix == null)
                Valido = false;
        }
    }
}
