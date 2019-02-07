using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Atividade2EFCore.Modelos
{
    class Contexto : DbContext
    {
        public DbSet<Agencia> Agencias { get; set; }
        public DbSet<Banco> Bancos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<ClienteSolicitacao> ClienteSolicitacoes { get; set; }
        public DbSet<ContaCorrente> ContasCorrentes { get; set; }
        public DbSet<ContaPoupanca> ContasPoupancas { get; set; }
        public DbSet<Solicitacao> Solicitacoes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=bancoBD.db");
        }
    }
}
