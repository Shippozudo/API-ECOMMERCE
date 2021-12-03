﻿using System;

namespace Exercicio02_API_Ecomerce.DTOs
{
    public class DebitoDTO : Validator
    {
        public string Titular { get;  set; }
        public string Numero { get;  set; }
        public string CVV { get;  set; }
        public decimal Saldo { get;  set; }
        public DateTime Validade { get;  set; }


        public override void Validar()
        {
            Valido = true;
            if (Validade == null)
                Valido = false;
            if(Saldo <= 0 )
                Valido = false;
            if (CVV == null)
                Valido = false;



        }

    }
}
