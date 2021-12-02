using System;
using Lil.Search.Models;

namespace Lil.Search.Interfaces
{
    public interface IProductService
    {
        Task<Product> GetAsync(string id);
    }
}

