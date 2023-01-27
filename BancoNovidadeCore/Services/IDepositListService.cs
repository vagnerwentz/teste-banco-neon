using System;
using BancoNovidadeCore.Domain;

namespace BancoNovidadeCore.Services
{
    public interface IDepositListService
    {
        Task<List<Deposit>> GetDepositListAsync();
    }
}

