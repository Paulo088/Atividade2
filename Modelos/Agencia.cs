using System;
using System.Collections.Generic;
using System.Text;

namespace Atividade2EFCore.Modelos
{
    class Agencia
    {
        private string numeroAgencia;
        private ICollection<Conta> contas = new List<Conta>();

        public ICollection<Conta> Contas { get; set; }
        public string NumeroAgencia { get => numeroAgencia; set => numeroAgencia = value; }
        public int Id { get; set; }
        public int BancoId { get; set; }
    }
}
