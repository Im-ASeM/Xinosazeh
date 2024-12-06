
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
    public IActionResult index()
    {
        return View();
    }
}