using System;
using System.Collections.Generic;
using System.Text;

namespace Atividade2EFCore.Modelos
{
    public class ContaPoupanca : Conta
    {
        private decimal juros = 0.1M;
        private string titular;
        private DateTime dataAniversario;

        public int Id { get; set; }
        public decimal Juros {  get; set; }
        public string Titular { get; set; }
        public DateTime DataAniversario { get; set; }
    }
}

