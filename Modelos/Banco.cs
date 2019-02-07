using System;
using System.Collections.Generic;

namespace Atividade2EFCore.Modelos
{
    class Banco
    {
        private string nome;
        private ICollection<Agencia> agencias = new List<Agencia>();

        public int Id { get; set; }
        public string Nome { get => nome; set => nome = value; }
        public ICollection<Agencia> Agencias { get; set; }
    }
}
