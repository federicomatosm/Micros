using Lil.Products.Controllers;
using Lil.Products.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lil.Products.Test;

[TestClass]
public class ProductsTest
{
    [TestMethod]
    public void GetAsyncReturnsOk()
    {
        var provider = new ProductsProvider();
        var controller = new ProductsController(provider);
        var result = controller.Get("2").Result;

        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result, typeof(OkObjectResult));
    }

    [TestMethod]
    public void GetAsyncReturnsNotFound()
    {
        var provider = new ProductsProvider();
        var controller = new ProductsController(provider);
        var result = controller.Get("2000").Result;

        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result, typeof(NotFoundResult));
    }
}
