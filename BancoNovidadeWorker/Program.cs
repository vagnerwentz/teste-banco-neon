using BancoNovidadeCore.Repositories;
using BancoNovidadeCore.Services;
using BancoNovidadeInfrastructure.Persistence;
using BancoNovidadeInfrastructure.Persistence.Repositories;
using BancoNovidadeWorker;
using BancoNovidadeWorker.Endpoints;
using Microsoft.EntityFrameworkCore;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHttpClient();
        services.AddScoped<IDepositListService, DepositListService>();
        services.AddScoped<IBankAccountService, BankAccountService>();
        services.AddScoped<IDepositInMemory, DepositInMemory>();
        services.AddDbContext<BancoNovidadeDbContext>(options => options.UseSqlServer("Server=localhost;Database=BancoNovidadeDatabase;User=sa;Password=BancoNovidade@word;"));
        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
