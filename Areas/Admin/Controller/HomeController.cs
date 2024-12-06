
using Microsoft.AspNetCore.Mvc;

namespace test.Areas.Admin.Controllers;
//add Area Admin
[Area("Admin")]
public class HomeController : Controller
{
    private readonly Context db;
    public HomeController(Context _db)
    {
        db = _db;
    }

    [HttpGet]
    public IActionResult NewWorkCat(NewWorkCat newCat)
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
        return Ok("ok shod");
    }

    [HttpGet]
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