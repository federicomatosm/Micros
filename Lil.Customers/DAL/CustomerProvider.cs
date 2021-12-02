using System;
using Lil.Customers.Models;

namespace Lil.Customers.DAL
{
    public class CustomerProvider: ICustomersProvider
    {
        private readonly List<Customer> repo = new List<Customer>();
        public CustomerProvider()
        {
            repo.Add(new Customer() { Id = "1", City = "Santo Domingo", Name = "Juan" });
            repo.Add(new Customer() { Id = "2", City = "Santo Jose de Ocoa", Name = "Federico" });
            repo.Add(new Customer() { Id = "3", City = "San Juan", Name = "Felix" });
            repo.Add(new Customer() { Id = "4", City = "Santiago", Name = "Josefina" });

        }

        public async Task<Customer> GetAsync(string id)
        {
            var result =  repo.FirstOrDefault(x => x.Id == id);
           
           
            return await Task.FromResult(result);
        }
    }
}

