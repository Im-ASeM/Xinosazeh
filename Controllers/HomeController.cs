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
    public IActionResult Work(int page = 1, int catId = 0)
    {
        if (page <= 0) page = 1;
        
        var Categories = db.WorkCategories_tbl.ToList();
        ViewBag.Categories = Categories;

        var Posts = db.WorkPosts_tbl.Include(x => x.Categories).ThenInclude(x => x.WorkCat).ToList();
        if (catId != 0)
        {
            Posts = Posts.Where(x=>x.Categories.Any(cat => cat.WorkCatId == catId)).ToList();
        }

        var AllPage = Convert.ToInt32(Math.Ceiling((double)Posts.Count / 6));

        if (page > AllPage) page = AllPage;
        ViewBag.AllPage = AllPage;
        ViewBag.Page = page;

        ViewBag.Catid = catId;
        ViewBag.Posts = Posts.Skip((page - 1) * 6).Take(6).ToList();

        ViewBag.Url = $"/work?CatId={catId}&page=";
        return View();
    }

    [HttpGet]
    public IActionResult Blog(int page = 1)
    {
        if (page <= 0) page = 1;

        var blogs = db.BlogPost_tbl.OrderByDescending(x => x.Id).ToList();
        ViewBag.LastBlogs = blogs.Take(2).ToList();

        var AllPage = Convert.ToInt32(Math.Ceiling((double)blogs.Count / 6));

        if (page > AllPage) page = AllPage;
        ViewBag.AllPage = AllPage;
        ViewBag.Page = page;

        ViewBag.blogs = blogs.Skip((page - 1) * 6).Take(6).ToList();
        ViewBag.url = "/blog?page=";
        return View();
    }

    [HttpGet]
    public IActionResult ContactUs()
    {
        return View();
    }
}
