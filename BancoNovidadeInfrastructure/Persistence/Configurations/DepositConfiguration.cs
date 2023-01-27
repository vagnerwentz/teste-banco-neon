using System;
using BancoNovidadeCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BancoNovidadeInfrastructure.Persistence.Configurations
{
    public class DepositConfiguration : IEntityTypeConfiguration<Deposit>
    {
        public void Configure(EntityTypeBuilder<Deposit> builder)
        {
            builder.HasKey(p => p.Id);
        }
    }
}

