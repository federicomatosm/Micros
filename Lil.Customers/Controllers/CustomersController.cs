using System;
using Lil.Customers.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Lil.Customers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController: ControllerBase
    {
        private readonly ICustomersProvider customerProvider;

        public CustomersController(ICustomersProvider customerProvider)
        {
            this.customerProvider = customerProvider;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(string id)
        {
            var result = await customerProvider.GetAsync(id);
            if(result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}

