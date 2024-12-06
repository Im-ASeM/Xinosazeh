using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
public class HomeController : Controller
{
    private readonly Context db;
    public HomeController(Context _db)
    {
        db = _db;
    }

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
        var Categories = db.WorkCategories_tbl.ToList();
        ViewBag.Categories = Categories;

        var Posts = db.WorkPosts_tbl.Include(x=>x.Categories).ThenInclude(x=>x.WorkCat).ToList();
        ViewBag.Posts = Posts;
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
