using Microsoft.AspNetCore.Mvc;
using aspCMS.Models;
using aspCMS.Data;
using System.ComponentModel;

namespace aspCMS.Controllers;

public class PostsController : Controller
{
    private readonly AppDBContext _db;

    public PostsController(AppDBContext db)
    {
        _db = db;
    }

    public IActionResult Index(string? id)
    {


        if (id == null || id == "fail")
        {
            return View(null);
        }
        else
        {

            Post postFound = _db.Posts.Where(post => post.Slug == id).FirstOrDefault();
            return View(postFound);
        }



    }

    public IActionResult Post(string? id)
    {
        if (id == null || id == "fail")
        {
            return View(null);
        }
        else
        {

            Post postFound = _db.Posts.Where(post => post.Slug == id).FirstOrDefault();
            return View(postFound);
        }

    }



}
