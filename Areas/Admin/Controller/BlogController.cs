
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace test.Areas.Admin.Controllers;
//add Area Admin
[Area("Admin")]
public class BlogController : Controller
{
    private readonly Context db;
    private readonly IWebHostEnvironment _env;
    public BlogController(Context _db, IWebHostEnvironment env)
    {
        db = _db;
        _env = env;
    }

    [HttpGet]
    public IActionResult index(int id = 1)
    {
        var Posts = db.BlogPost_tbl.OrderByDescending(x => x.Id).ToList();
        ViewBag.Posts = Posts;

        ViewBag.PageNum = id;
        return View();
    }

    public IActionResult DelPost(int id)
    {
        var check = db.BlogPost_tbl.Find(id);
        if (check == null) return RedirectToAction("index", "Blog", new { Area = "Admin" });
        db.BlogPost_tbl.Remove(check);
        db.SaveChanges();
        return RedirectToAction("index", "Blog", new { Area = "Admin" });
    }

    [HttpGet]
    public IActionResult AddPost()
    {
        return View();
    }

    [HttpPost]
    public async Task<ActionResult> NewPost(NewBlogPost NewPost)
    {

        if (NewPost.HaveKeyWords() && NewPost.isNullOrEmpty())
        {
            return BadRequest("khalie");
        }

        List<string> images = new List<string>();
        foreach (var img in NewPost.images)
        {
            images.Add(await patherAsync(img));
        }

        blogPost result = new blogPost
        {
            body = NewPost.body,
            Discription = NewPost.Discription,
            images = images,
            mainImg = await patherAsync(NewPost.mainImg),
            Title = NewPost.Title,
            CreateDate = DateTime.UtcNow,
            KeyWords = NewPost.KeyWords,
            Comments = []
        };


        db.BlogPost_tbl.Add(result);
        db.SaveChanges();

        return RedirectToAction("index", "Blog", new { Area = "Admin" });
    }


    private async Task<string> patherAsync(IFormFile file)
    {
        string FileExtension = Path.GetExtension(file.FileName);
        var NewFileName = String.Concat(Guid.NewGuid().ToString(), FileExtension);
        var uploadsDirectory = $"{_env.WebRootPath}/uploads";

        if (!Directory.Exists(uploadsDirectory))
        {
            Directory.CreateDirectory(uploadsDirectory);
        }

        var path = $"{_env.WebRootPath}/uploads/{NewFileName}";
        var PathSave = $"/uploads/{NewFileName}";
        using (var stream = new FileStream(path, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }
        return PathSave;
    }
}