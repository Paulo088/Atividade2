using System;
using System.Collections.Generic;
using System.Text;

namespace Atividade2EFCore.Modelos
{
    public abstract class Conta
    {
        private decimal saldo;
        private string titular;

        public int Id { get; set; }
        public decimal Saldo { get; set; }
        public string Titular { get; set; }
    }
}
