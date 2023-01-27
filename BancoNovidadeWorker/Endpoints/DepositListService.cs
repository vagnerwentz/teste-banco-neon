using System;
using BancoNovidadeCore.Domain;
using BancoNovidadeCore.Services;
using Newtonsoft.Json;

namespace BancoNovidadeWorker.Endpoints
{
    public class DepositListService : IDepositListService
    {
        private readonly HttpClient client;
        private readonly string _baseURL;
        private readonly string UUID = "68cc9f8b-519b-4057-bf3c-804115e68fd4";

        public DepositListService(HttpClient client, IConfiguration configuration)
        {
            this.client = client;
            _baseURL = configuration["Services:BaseURL"];
        }

        public async Task<List<Deposit>> GetDepositListAsync()
        {
            var response = await client.GetAsync($"{_baseURL}/{UUID}");
            var depositListString = await response.Content.ReadAsStringAsync();
            var depositList = JsonConvert.DeserializeObject<List<Deposit>>(depositListString);

            return depositList;
        }
    }
}

