using System;
using Atividade2EFCore.Modelos;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;

namespace Atividade2EFCore
{
    class Program
    {
        public const string TIPO_DEPOSITO = "DEPOSITO";
        public const string TIPO_SAQUE = "SAQUE";

        static void Main(string[] args)
        {
            var contexto = new Contexto();
            if (!contexto.Bancos.Any())
            {
                var banco = new Banco() { Nome = "Banco do Brasil" };
                contexto.Add(banco);
                contexto.SaveChanges();

                if (!contexto.Agencias.Any())
                {
                    var Agencia = new Agencia() { NumeroAgencia = "001", BancoId = banco.Id };
                    contexto.Add(Agencia);
                    contexto.SaveChanges();
                }
            }

            foreach (Agencia a in contexto.Agencias)
            {
                Console.WriteLine("bancoId: " + a.BancoId);
            }


            while (true)
            {
                Console.WriteLine("Digite a opcao desejada.");
                Console.WriteLine("1 - Listar agencias");
                Console.WriteLine("2 - Agencia");
                Console.WriteLine("3 - Conta");
                Console.WriteLine("0 - Sair");

                int op = int.Parse(Console.ReadLine());
                Console.WriteLine(op);
                if (op == 0)
                {
                    break;
                }

                if (op == 1)
                {
                    List<Banco> bancos = contexto.Bancos.ToList();
                    foreach (Agencia a in bancos[0].Agencias)
                    {
                        Console.WriteLine("Identificador: " + a.NumeroAgencia);
                    }
                }
                else if (op == 2)
                {
                    Console.WriteLine("Numero da agencia.");
                    string agencia = Console.ReadLine();

                    Agencia a = null;

                    List<Banco> bancos = contexto.Bancos.ToList();
                    foreach (Agencia ag in bancos[0].Agencias)
                    {
                        if (ag.NumeroAgencia.Equals(agencia))
                        {
                            a = ag;
                            break;
                        }
                    }
                    if(a == null)
                    {
                        Console.WriteLine("Agencia nao encontrada.");
                        continue;
                    }

                    Console.WriteLine("Agencia " + a.NumeroAgencia);
                    Console.WriteLine("1 - Abrir conta");
                    Console.WriteLine("2 - Fechar conta");
                    Console.WriteLine("3 - Consultar conta");
                    Console.WriteLine("0 - Voltar");
                    op = int.Parse(Console.ReadLine());

                    if (op == 1)
                    {
                        Console.WriteLine("Digite 1. Conta Corrente 2.Conta Poupanca ");
                        op = int.Parse(Console.ReadLine());

                        if (op == 1)
                        {
                            Console.WriteLine("Digite o nome do titular ");
                            string nome = Console.ReadLine();
                            
                            ContaCorrente cc = new ContaCorrente();
                            cc.Titular = nome;
                            contexto.Add(cc);
                            a.Contas.Add(cc);
                            contexto.SaveChanges();
                            continue;
                        }
                        else if (op == 2)
                        {
                            Console.WriteLine("Digite o nome do titular ");
                            string nome = Console.ReadLine();
                            ContaPoupanca cp = new ContaPoupanca();
                            cp.Titular = nome;
                            Console.WriteLine("Digite sua data de aniversario ");
                            string niver = Console.ReadLine();
                            cp.DataAniversario = DateTime.ParseExact(niver, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            contexto.Add(cp);
                            a.Contas.Add(cp);
                            contexto.SaveChanges();
                            continue;
                        }
                    }
                    else if (op == 2)
                    {
                        Console.WriteLine("Digite o nome do titular.");
                        string nome = Console.ReadLine();
                        Console.WriteLine("Digite 1. Conta Corrente 2.Conta Poupanca ");
                        op = int.Parse(Console.ReadLine());
                        if (op == 1)
                        {
                            foreach (ContaCorrente cc in contexto.ContasCorrentes)
                            {
                                if (cc.Titular.Equals(nome))
                                {
                                    contexto.ContasCorrentes.Remove(cc);
                                    a.Contas.Remove(cc);
                                    contexto.SaveChanges();
                                    break;
                                }
                            }


                        }else if (op == 2)
                        {
                            foreach (ContaPoupanca cp in contexto.ContasPoupancas)
                            {
                                if (cp.Titular.Equals(nome))
                                {
                                    contexto.ContasPoupancas.Remove(cp);
                                    a.Contas.Remove(cp);
                                    contexto.SaveChanges();
                                    break;
                                }
                            }

                        }

                    }
                    else if (op == 3)
                    {
                        
                        Console.WriteLine("Digite 1. Conta Corrente 2.Conta Poupanca ");
                        op = int.Parse(Console.ReadLine());

                        if (op == 1)
                        {
                            Console.WriteLine("Digite o nome do titular ");
                            string nome = Console.ReadLine();
                            foreach (ContaCorrente cc in contexto.ContasCorrentes)
                            {
                                if (cc.Titular.Equals(nome))
                                {
                                    Console.WriteLine("Identificador: " + cc.Id + " | Saldo: " + cc.Saldo);
                                    break;
                                }
                            }
                            continue;
                        }
                        else if (op == 2)
                        {
                            Console.WriteLine("Digite o nome do titular ");
                            string nome = Console.ReadLine();
                            foreach (ContaPoupanca cp in contexto.ContasPoupancas)
                            {
                                if (cp.Titular.Equals(nome))
                                {
                                    Console.WriteLine("Identificador: " + cp.Id + " | Saldo: " + cp.Saldo);
                                    break;
                                }
                            }
                            continue;
                        }                          
                        
                    }
                    
                }
                else if (op == 3)
                {
                    Console.WriteLine("Conta.");
                    Console.WriteLine("1 - Solicitar");                  
                    Console.WriteLine("0 - Voltar");

                    op = int.Parse(Console.ReadLine());

                    if (op == 1)
                    {
                        Solicitacao s = new Solicitacao();
                        Console.WriteLine("digite Cpf do cliente");
                        string CpfCliente = Console.ReadLine();
                        Console.WriteLine("digite agencia do cliente");
                        string NumeroAgencia = Console.ReadLine();
                        Console.WriteLine("digite o tipo de transacao: (1- Deposito 2 - Saque) ");
                        int opc = int.Parse(Console.ReadLine());

                        List<Agencia> agencias = contexto.Agencias.ToList();
                        Agencia a = null;
                        foreach(Agencia ag in agencias)
                        {
                            if (ag.NumeroAgencia.Equals(NumeroAgencia))
                            {
                                a = ag;
                                break;
                            }
                        }

                        if(a == null)
                        {
                            Console.WriteLine("Agencia nao encontrada");
                            continue;                            
                        }

                        if (opc == 1)
                        {
                            s.TipoT = TIPO_DEPOSITO;
                        }
                        else if (opc == 2)
                        {
                            s.TipoT = TIPO_SAQUE;
                        }

                        if (s.TipoT.Equals(TIPO_DEPOSITO))
                        {
                          
                            Console.WriteLine("digite a conta");
                            string conta = Console.ReadLine();
                                                      
                            Console.WriteLine("Digite 1 - Conta Corrente 2 - Conta Poupanca ");
                            opc = int.Parse(Console.ReadLine());

                            if (opc == 1)
                            {
                                ContaCorrente c = null;

                                foreach (ContaCorrente cc in a.Contas)
                                {
                                    if (cc.Titular.Equals(conta))
                                    {
                                        c = cc;
                                        break;
                                    }
                                }

                                if (c == null)
                                {
                                    Console.WriteLine("Conta nao encontrada");
                                    break;
                                }
                                                                
                                Console.WriteLine("Valor a ser Depositado");
                                decimal valor = decimal.Parse(Console.ReadLine());

                                decimal taxa = valor * c.Taxa;
                                c.Saldo = c.Saldo + valor - taxa;

                                Console.WriteLine("Valor atual: " + c.Saldo);
                                contexto.SaveChanges();
                            }

                            else if (opc == 2)
                            {
                                ContaPoupanca p = null;

                                foreach (ContaPoupanca cp in a.Contas)
                                {
                                    if (cp.Titular.Equals(conta))
                                    {
                                        p = cp;
                                        break;
                                    }
                                }

                                if (p == null)
                                {
                                    Console.WriteLine("Conta nao encontrada");
                                    break;
                                }
                                                                
                                Console.WriteLine("Valor a ser Depositado");
                                decimal valor = int.Parse(Console.ReadLine());

                                decimal taxa = valor * p.Juros;
                                p.Saldo = p.Saldo + valor + taxa;

                                Console.WriteLine("Valor atual: " + p.Saldo);
                                contexto.SaveChanges();

                            }
                        }
                       
                        else if (s.TipoT.Equals(TIPO_SAQUE))
                        {

                            Console.WriteLine("digite a conta");
                            string conta = Console.ReadLine();

                            Console.WriteLine("Digite 1 - Conta Corrente 2 - Conta Poupanca ");
                            opc = int.Parse(Console.ReadLine());

                            if (opc == 1)
                            {
                                ContaCorrente c = null;

                                foreach (ContaCorrente cc in a.Contas)
                                {
                                    if (cc.Titular.Equals(conta))
                                    {
                                        c = cc;
                                        break;
                                    }
                                }

                                if (c == null)
                                {
                                    Console.WriteLine("Conta nao encontrada");
                                    break;
                                }

                                Console.WriteLine("Valor a ser Sacado ");
                                decimal valor = decimal.Parse(Console.ReadLine());

                                if (c.Saldo >= valor)
                                {
                                    c.Saldo = c.Saldo - valor;

                                    Console.WriteLine("Valor atual: " + c.Saldo);
                                    contexto.SaveChanges();
                                } else
                                {
                                    Console.WriteLine("Saldo insufuciente.");
                                    continue;
                                }
                            }
                            else if (op == 2)
                            {
                                ContaPoupanca p = null;

                                foreach (ContaPoupanca cp in a.Contas)
                                {
                                    if (cp.Titular.Equals(conta))
                                    {
                                        p = cp;
                                        break;
                                    }
                                }

                                if (p == null)
                                {
                                    Console.WriteLine("Conta nao encontrada");
                                    break;
                                }

                                Console.WriteLine("Valor a ser Sacado");
                                decimal valor = decimal.Parse(Console.ReadLine());

                                if (p.Saldo >= valor)
                                {
                                    p.Saldo = p.Saldo - valor;

                                    Console.WriteLine("Valor atual: " + p.Saldo);
                                    contexto.SaveChanges();
                                }
                                else
                                {
                                    Console.WriteLine("Saldo insufuciente.");
                                    continue;
                                }
                            }
                        }
                    }

                }
                 else if (op == 0)
                 {
                    continue;
                 }
            }
        }
    }
}
