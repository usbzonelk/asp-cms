using Microsoft.AspNetCore.Mvc;
using aspCMS.Models;
using aspCMS.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Post newPost)
    {
        if (ModelState.IsValid)
        {
            try
            {
                _db.Posts.Add(newPost);
                _db.SaveChanges();
                ViewData["Message"] = $"{newPost.Title} was added successfully";

            }
            catch (Exception e)
            {
                var errName = e.GetBaseException().Message;
                ViewData["Error"] = errName;
                Console.WriteLine(errName);
            }
        }
        else
        {
            Console.WriteLine("\nModel is invalid");

        }
        return View();

    }
}
