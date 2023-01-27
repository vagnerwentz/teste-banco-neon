using System;
using BancoNovidadeCore.Domain;

namespace BancoNovidadeCore.Services
{
    public interface IBankAccountService
    {
        Task<List<BankAccount>> GetBankAccountsAsync();
    }
}

