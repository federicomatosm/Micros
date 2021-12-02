using System;
using Lil.Search.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lil.Search.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController:ControllerBase
    {
        private readonly ICustomersService customersServices;
        private readonly IProductService productServices;
        private readonly ISalesService salesService;

        public SearchController(ICustomersService customersServices, IProductService productServices, ISalesService salesService)
        {
            this.customersServices = customersServices;
            this.productServices = productServices;
            this.salesService = salesService;
        }
        [HttpGet("{customerId}")]
        public async Task<IActionResult> SearchAsync(string customerId)
        {
            if (string.IsNullOrEmpty(customerId))
                return BadRequest();
            try
            {
                var customer = await  customersServices.GetAsync(customerId);
                var sales = await  salesService.GetAsync(customerId);
                
                foreach(var sale in sales)
                {
                    foreach(var item in sale.Items)
                    {
                        
                        item.Product = await productServices.GetAsync(item.ProductId);
                    }
                }
                var result = new
                {
                    Customer = customer,
                    Sales = sales
                };

                return Ok(result);
            }
            catch (Exception)
            {

            }

            return NotFound();

        }
        
    }
}

