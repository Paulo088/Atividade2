using System;
using System.Collections.Generic;
using System.Text;

namespace Atividade2EFCore.Modelos
{
    class ClienteSolicitacao
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int SolicitacaoId { get; set; }
    }
}
