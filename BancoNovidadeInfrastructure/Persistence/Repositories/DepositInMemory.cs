using System;
using System.Collections.Generic;
using BancoNovidadeCore.Domain;
using BancoNovidadeCore.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BancoNovidadeInfrastructure.Persistence.Repositories
{
    public class DepositInMemory : IDepositInMemory
    {
        private readonly BancoNovidadeDbContext _dbContext;
        public DepositInMemory(BancoNovidadeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Deposit>> GetDeposits()
        {
            return await _dbContext.Deposits.ToListAsync();
        }

        public async Task SaveDeposit(Deposit deposit)
        {
            await _dbContext.Deposits.AddAsync(deposit);
        }
    }
}

