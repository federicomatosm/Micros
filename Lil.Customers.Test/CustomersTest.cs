using Lil.Customers.Controllers;
using Lil.Customers.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lil.Customers.Test;

[TestClass]
public class CustomersTest
{
    [TestMethod]
    public void GetAsyncReturnsOk()
    {
        var customerProvider = new CustomerProvider();
        var customerController = new CustomersController(customerProvider);
        var result = customerController.GetAsync("1").Result;

        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result, typeof(OkObjectResult));
    }

    [TestMethod]
    public void GetAsyncReturnsNotFound()
    {
        var customerProvider = new CustomerProvider();
        var customerController = new CustomersController(customerProvider);
        var result = customerController.GetAsync("88").Result;

        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result, typeof(NotFoundResult));
    }
}
