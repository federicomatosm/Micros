using System.Collections.Generic;
using Lil.Sales.Controllers;
using Lil.Sales.DAL;
using Lil.Sales.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lil.Sales.Test;

[TestClass]
public class SalesTest

{
    [TestMethod]
    public void GetAsyncResultOk()
    {
        var provider = new SalesProvider();
        var controller = new SalesController(provider);

       var result = provider.GetAsync("1").Result;

        Assert.IsNotNull(result);

        Assert.IsInstanceOfType(result, typeof(List<Order>));
    }

    [TestMethod]
    public void GetAsyncResultNotFound()
    {
        var provider = new SalesProvider();
        var controller = new SalesController(provider);

        var result = provider.GetAsync("1000").Result;

        Assert.IsNotNull(result);

        Assert.IsInstanceOfType(result, typeof(NotFoundResult));
    }
}
