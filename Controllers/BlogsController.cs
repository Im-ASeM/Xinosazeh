using System.Data;
using Microsoft.AspNetCore.Mvc;

public class BlogsController : Controller
{
    private readonly Context db;
    public BlogsController(Context _db)
    {
        db = _db;
    }

    [HttpGet]
    public IActionResult Details(int id)
    {
        var post = db.BlogPost_tbl.Find(id);
        if (post != null)
        {
            ViewBag.Title = post.Title;
            ViewBag.Discription = post.Discription;
            ViewBag.Comments = post.Comments;
            ViewBag.mainImg = post.mainImg;
            ViewBag.images = post.images;
            ViewBag.body = post.body;
            ViewBag.KeyWords = post.KeyWords;
            ViewBag.CreateDate = post.CreateDate;
            ViewBag.LastBlogs = db.BlogPost_tbl.OrderByDescending(x => x.Id).Take(2).ToList();
            return View();
        }

        return RedirectToAction("blog","home");
    }
}