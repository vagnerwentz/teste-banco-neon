using System;
namespace BancoNovidadeCore.Domain
{
    public class BankAccount
    {
        public BankAccount(string id, string nome, string agencia, string conta)
        {
            Id = id;
            Nome = nome;
            Agencia = agencia;
            Conta = conta;
        }

        public string Id { get; set; }
        public string Nome { get; set; }
        public string Agencia { get; set; }
        public string Conta { get; set; }
    }
}

