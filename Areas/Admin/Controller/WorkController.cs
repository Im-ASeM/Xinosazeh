
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace test.Areas.Admin.Controllers;
//add Area Admin
[Area("Admin")]
public class WorkController : Controller
{
    private readonly Context db;
    public WorkController(Context _db)
    {
        db = _db;
    }

    [HttpGet]
    public IActionResult index(int id = 1)
    {
        var Posts = db.WorkPosts_tbl.Include(x => x.Categories).ThenInclude(x => x.WorkCat).ToList();
        ViewBag.Posts = Posts;

        ViewBag.PageNum = id;
        return View();
    }

    [HttpGet]
    public IActionResult Categories()
    {
        var Category = db.WorkCategories_tbl.Include(x => x.Subs).ToList();
        ViewBag.Categories = Category;
        return View();
    }

    [HttpPost]
    public IActionResult AddCat(NewWorkCat newCat)
    {
        if (newCat.isNullOrEmpty())
        {
            return BadRequest("khalie");
        }

        WorkCategory result = new WorkCategory
        {
            WorkCatName = newCat.WorkCatName
        };

        db.WorkCategories_tbl.Add(result);
        db.SaveChanges();
        return RedirectToAction("Categories", "work", new { Area = "Admin" });
    }

    public IActionResult DelCat(int id)
    {
        var check = db.WorkCategories_tbl.Find(id);
        if (check == null) return RedirectToAction("index", "work", new { Area = "Admin" });
        db.WorkCategories_tbl.Remove(check);
        db.SaveChanges();
        return RedirectToAction("Categories", "work", new { Area = "Admin" });
    }
    public IActionResult DelPost(int id)
    {
        var check = db.WorkPosts_tbl.Find(id);
        if (check == null) return RedirectToAction("index", "work", new { Area = "Admin" });
        db.WorkPosts_tbl.Remove(check);
        db.SaveChanges();
        return RedirectToAction("index", "work", new { Area = "Admin" });
    }

    [HttpGet]
    public IActionResult AddWorkPost()
    {
        var Category = db.WorkCategories_tbl.ToList();
        ViewBag.Categories = Category;
        return View();
    }

    [HttpPost]
    public IActionResult NewWorkPost(NewWorkPost NewPost)
    {
        if (NewPost.isNullOrEmpty())
        {
            return BadRequest("khalie");
        }

        WorkPost result = new WorkPost
        {
            body = NewPost.body,
            Discription = NewPost.Discription,
            footer = NewPost.footer,
            images = NewPost.images,
            mainImg = NewPost.mainImg,
            Title = NewPost.Title
        };

        db.WorkPosts_tbl.Add(result);
        db.SaveChanges();

        foreach (int id in NewPost.CategoriesId)
        {
            WorkPC cat = new WorkPC
            {
                WorkCatId = id,
                WorkPostId = result.Id
            };
            db.WorkPC_tbl.Add(cat);
            db.SaveChanges();
        }
        return Ok("ok shod");
    }
}