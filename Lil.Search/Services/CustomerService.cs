using System;
using Lil.Search.Interfaces;
using Lil.Search.Models;
using System.Text.Json;

namespace Lil.Search.Services
{
    public class CustomerService : ICustomersService
    {
        private readonly IHttpClientFactory httpClientFactory;

        public CustomerService(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<Customer> GetAsync(string id)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var client = httpClientFactory.CreateClient("customerService");
            var response = await client.GetAsync($"api/customers/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var customer =  JsonSerializer.Deserialize<Customer>(content, options);
                
                return customer;
            }
            return null;
        }
    }
}

