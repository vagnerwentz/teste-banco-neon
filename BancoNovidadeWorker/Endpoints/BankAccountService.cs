using System;
using BancoNovidadeCore.Domain;
using BancoNovidadeCore.Services;
using Newtonsoft.Json;

namespace BancoNovidadeWorker.Endpoints
{
    public class BankAccountService : IBankAccountService
    {
        private readonly HttpClient client;
        private readonly string _baseURL;
        private readonly string UUID = "7f0acd4b-e63d-4571-b834-c3db15f70673";

        public BankAccountService(HttpClient client, IConfiguration configuration)
        {
            this.client = client;
            _baseURL = configuration["Services:BaseURL"];
        }

        public async Task<List<BankAccount>> GetBankAccountsAsync()
        {
            var responseBankAccounts = await client.GetAsync($"{_baseURL}/{UUID}");
            var bankAccountsString = await responseBankAccounts.Content.ReadAsStringAsync();
            var bankAccounts = JsonConvert.DeserializeObject<List<BankAccount>>(bankAccountsString);

            return bankAccounts;
        }
    }
}

