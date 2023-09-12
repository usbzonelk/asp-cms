using Microsoft.AspNetCore.Mvc;
using aspCMS.Models;
using aspCMS.Data;

namespace aspCMS.Controllers;

public class PostsController : Controller
{
    private readonly AppDBContext _db;

    public PostsController(AppDBContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        List<Post> postsList = _db.Posts.ToList();
        return View(postsList);
    }



}
