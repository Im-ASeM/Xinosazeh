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

        var Posts = db.WorkPosts_tbl.Include(x => x.Categories).ThenInclude(x => x.WorkCat).ToList();
        ViewBag.Posts = Posts;
        return View();
    }

    [HttpGet]
    public IActionResult Blog()
    {
        var blogs = db.BlogPost_tbl.ToList();
        blogs.Add(new blogPost
        {
            body = "body",
            Comments = new List<blogComment>(),
            CreateDate = DateTime.UtcNow,
            Discription = "Discription",
            footer = "footer",
            Id = 1,
            images = new List<string>() { "/wp-content/uploads/2020/03/post1-3.jpg", "/wp-content/uploads/2020/03/post1-3.jpg" },
            mainImg = "/uploads/6d8cc40e-bbaa-439a-be9a-53b20e082e98.JPG",
            KeyWords = new List<string>() { "salam", "khodafez" },
            Title = "title vagheii"
        });
        blogs.Add(new blogPost
        {
            body = "body",
            Comments = new List<blogComment>(),
            CreateDate = DateTime.UtcNow,
            Discription = "Discription",
            footer = "footer",
            Id = 1,
            images = new List<string>() { "/wp-content/uploads/2020/03/post1-3.jpg", "/wp-content/uploads/2020/03/post1-3.jpg" },
            mainImg = "/uploads/6d8cc40e-bbaa-439a-be9a-53b20e082e98.JPG",
            KeyWords = new List<string>() { "salam", "khodafez" },
            Title = "title vagheii 2"
        });
        ViewBag.LastBlogs = blogs.OrderByDescending(x => x.Id).Take(2).ToList();
        ViewBag.blogs = blogs;

        return View();
    }

    [HttpGet]
    public IActionResult ContactUs()
    {
        return View();
    }
}
