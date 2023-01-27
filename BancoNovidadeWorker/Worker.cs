using System.Security.Principal;
using BancoNovidadeCore.Domain;
using BancoNovidadeCore.Repositories;
using BancoNovidadeCore.Services;
using Newtonsoft.Json;

namespace BancoNovidadeWorker;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IDepositInMemory _depositInMemory;
    readonly HashSet<string> uniqueAccounts = new HashSet<string>();
    readonly List<BankAccount> filteredBankAccount = new List<BankAccount>();
    private readonly IBankAccountService _bankAccountService;
    private readonly IDepositListService _depositListService;

    public Worker(ILogger<Worker> logger, IDepositInMemory depositInMemory, IBankAccountService bankAccountService, IDepositListService depositListService)
    {
        _logger = logger;
        _depositInMemory = depositInMemory;
        _bankAccountService = bankAccountService;
        _depositListService = depositListService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        try
        {
            _logger.LogInformation("Worker started at: {time}", DateTimeOffset.Now);

            var depositList = await _depositListService.GetDepositListAsync();
            var bankAccounts = await _bankAccountService.GetBankAccountsAsync();

            foreach (var account in bankAccounts)
            {
                if (uniqueAccounts.Add(account.Conta))
                {
                    filteredBankAccount.Add(account);
                }
            }

            var validDeposits = ValidateDepositAccountExistsAtBankAccounts(depositList, filteredBankAccount);

            foreach (Deposit deposit in validDeposits)
            {
                if (deposit.Nome is null)
                {
                    _logger.LogInformation("Deposit unsuccessfully for this deposit identification - {depositId} because the Nome property can not be null.", deposit.Id);
                    deposit.DepositoComSucesso(false);
                }

                await _depositInMemory.SaveDeposit(deposit);
                _logger.LogInformation("Deposit successfully for this deposit identification - {depositId}", deposit.Id);
            }
        } catch (Exception ex)
        {
            _logger.LogError("An error occured at: {exception}", ex);
        }
    }

    protected static IEnumerable<Deposit> ValidateDepositAccountExistsAtBankAccounts(List<Deposit> deposits, List<BankAccount> accounts)
    {
        return deposits.Where(deposit => accounts.Any(account => account.Agencia == deposit.AgenciaDestino && account.Conta == deposit.ContaDestino));
    }
}
