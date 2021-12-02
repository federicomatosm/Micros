using System;
using Lil.Sales.Models;

namespace Lil.Sales.DAL
{
    public class SalesProvider: ISalesProvider
    {
        private readonly List<Order> repo = new List<Order>();

        public SalesProvider()
        {
            for(int x=0; x<100; x++)
            {
                repo.Add(new Order()
                {
                    Id = (x + 1).ToString(),
                    CustomerId = "1",
                    OrderDate = DateTime.Now.AddMonths(-1),
                    Total = (5 * x),
                    Items = new List<OrderItem>()
                    {
                        new OrderItem() { Id = x + 2, OrderId = (x + 1).ToString(), Price = (x * 3.5), ProductId = "23", Quantity = x * 2 }
                    }
                    

                });
            }

            
        }

        public async Task<ICollection<Order>> GetAsync(string customerId)
        {
            var orders = repo.Where(x => x.CustomerId == customerId).ToList();
            
            return await Task.FromResult((ICollection<Order>)orders);
        }
    }
}

