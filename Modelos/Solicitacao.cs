using System;
using System.Collections.Generic;
using System.Text;

namespace Atividade2EFCore.Modelos
{
    class Solicitacao
    {
        private int clienteId;
        private int agenciaId;
        private int contaSaqueId;
        private int contaDepositoId;
        private string tipoT;
        private decimal valor;

        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int AgenciaId { get; set; }
        public int ContaSaqueId { get; set; }
        public int ContaDepositoId { get; set; }
        public string TipoT { get => tipoT; set => tipoT = value; }
        public decimal Valor { get => valor; set => valor = value; }
    }
}
