using Microsoft.AspNetCore.Mvc;
public class HomeController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Home2()
    {
        return View();
    }
    
    [HttpGet]
    public IActionResult AboutUs()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Service()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Work()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Blog()
    {
        return View();
    }

    [HttpGet]
    public IActionResult ContactUs()
    {
        return View();
    }
}
