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
            ViewBag.footer = post.footer;
            ViewBag.KeyWords = post.KeyWords;

            return View();
        }
        post = new blogPost
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

        };
        ViewBag.Title = post.Title;
        ViewBag.Discription = post.Discription;
        ViewBag.Comments = post.Comments;
        ViewBag.mainImg = post.mainImg;
        ViewBag.images = post.images;
        ViewBag.body = post.body;
        ViewBag.footer = post.footer;
        ViewBag.KeyWords = post.KeyWords;
        ViewBag.CreateDate = post.CreateDate;


        var blogs = db.BlogPost_tbl.OrderByDescending(x => x.Id).ToList();
        if (blogs.Count == 0)
        {
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
        }
        ViewBag.LastBlogs = blogs.OrderByDescending(x => x.Id).Take(2).ToList();
        return View();
    }
}