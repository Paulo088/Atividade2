using System;
using System.Collections.Generic;
using System.Text;

namespace Atividade2EFCore.Modelos
{
    class Cliente
    {
        private string nome;
        private string cpf;
        private string conta;

        public int Id { get; set; }
        public string Nome { get => nome; set => nome = value; }
        public string Cpf { get => cpf; set => cpf = value; }
        public string Conta { get => conta; set => conta = value; }
    }
}
