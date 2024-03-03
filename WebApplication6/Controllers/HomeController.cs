using Microsoft.AspNetCore.Mvc;
using WebApplication6.Models;
using WebApplication6.Extensions;

public class HomeController : Controller
{
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(User user)
    {
        if (user.Age > 16)
        {
            return RedirectToAction("Order");
        }
        return View();
    }

    [HttpGet]
    public IActionResult Order()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Order(int productCount)
    {
        return RedirectToAction("OrderForm", new { productCount = productCount });
    }

    [HttpGet]
    public IActionResult OrderForm(int productCount)
    {
        ViewBag.ProductCount = productCount;
        var orderDetails = new OrderDetails();
        for (int i = 0; i < productCount; i++)
        {
            orderDetails.Products.Add(new Product());
        }
        
        return View(orderDetails);
    }
    
    [HttpPost]
    public IActionResult OrderForm(OrderDetails orderDetails)
    {
        TempData.Put("OrderDetails", orderDetails);
        return RedirectToAction("OrderInfo");
    }


    public IActionResult OrderInfo()
    {
        var orderDetails = TempData.Get<OrderDetails>("OrderDetails");
        return View(orderDetails);
    }
}
