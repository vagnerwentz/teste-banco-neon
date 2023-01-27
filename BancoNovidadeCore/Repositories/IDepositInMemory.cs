using System;
using BancoNovidadeCore.Domain;

namespace BancoNovidadeCore.Repositories
{
    public interface IDepositInMemory
    {
        Task<List<Deposit>> GetDeposits();
        Task SaveDeposit(Deposit deposit);
    }
}

