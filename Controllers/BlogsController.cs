using Microsoft.AspNetCore.Mvc;

public class BlogsController : Controller
{

    [HttpGet]
    public IActionResult Details(int id)
    {
        return View();
    }
}