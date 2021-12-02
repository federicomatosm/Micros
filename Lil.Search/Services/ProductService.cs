using System;
using Lil.Search.Interfaces;
using Lil.Search.Models;
using System.Text.Json;

namespace Lil.Search.Services
{
    public class ProductService : IProductService
    {
        private readonly IHttpClientFactory httpClientFactory;

        public ProductService(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<Product> GetAsync(string id)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var client = httpClientFactory.CreateClient("productsServices");
            var response = await client.GetAsync($"api/products/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var products = JsonSerializer.Deserialize<Product>(content, options);

                return products;

            }
            return null;
        }
    }
}

