using System;
using System.Collections.Generic;
using System.Text;

namespace Atividade2EFCore.Modelos
{
    public class ContaCorrente : Conta
    {
        private decimal taxa = 0.10M;
        private string titular;

        public int Id { get; set; }
        public decimal Taxa { get; set; }
        public string Titular { get; set; }
    }

}
