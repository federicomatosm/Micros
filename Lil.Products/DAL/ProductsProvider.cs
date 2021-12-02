using System;
using Lil.Products.Models;

namespace Lil.Products.DAL
{
    public class ProductsProvider: IProductsProvider
    {
        private List<Product> repo = new List<Product>();
        public ProductsProvider()
        {
            for(int x=0; x<100; x++)
            {
                repo.Add(new Product()
                {
                    Id = (x + 1).ToString(),
                    Name = $"Product {x}",
                    Price = (double)x * 3.14
                }); 
            }
        }

        public async Task<Product> GetAsync(string id)
        {
            var product = repo.FirstOrDefault(x => x.Id == id);
           
            return await Task.FromResult(product);
        }
    }
}

