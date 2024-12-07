using Microsoft.AspNetCore.Mvc;
public class WorksController : Controller
{
    private readonly Context db;
    public WorksController(Context _db)
    {
        db = _db;
    }

    [HttpGet]
    public IActionResult Details(int Id)
    {
        var post = db.WorkPosts_tbl.Find(Id);
        if (post != null)
        {
            string title = post.Title;
            string discription = post.Discription;
            string body = post.body;
            string footer = post.footer;
            List<string> images = post.images;
            string mainImg = post.mainImg;

            ViewBag.title = title;
            ViewBag.discription = discription;
            ViewBag.body = body;
            ViewBag.images = images;
            ViewBag.mainImg = mainImg;
            ViewBag.footer = footer;

            return View();
        }
        else
        {
            return RedirectToAction("index", "home");
        }


    }
}