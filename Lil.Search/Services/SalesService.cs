using System;
using Lil.Search.Interfaces;
using Lil.Search.Models;
using System.Text.Json;

namespace Lil.Search.Services
{
    public class SalesService: ISalesService
    {
        private readonly IHttpClientFactory httpClientFactory;

        public SalesService(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<ICollection<Order>> GetAsync(string customerId)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var client = httpClientFactory.CreateClient("salesService");
            var response =  await client.GetAsync($"api/sales/{customerId}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var orders = JsonSerializer.Deserialize<ICollection<Order>>(content, options);

                return orders;
            }
            return null;
        }
    }
}

