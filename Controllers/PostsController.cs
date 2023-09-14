using Microsoft.AspNetCore.Mvc;
using aspCMS.Models;
using aspCMS.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Options;

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
                TempData["Message"] = $"{newPost.Title} was added successfully";

            }
            catch (Exception e)
            {
                var errName = e.GetBaseException().Message;
                TempData["Error"] = errName;
                Console.WriteLine(errName);
            }
        }
        else
        {

            Console.WriteLine();

        }
        return View();

    }


    public IActionResult Edit(string id)
    {
        string? Slug = id;
        if (Slug != null)
        {
            Post postToEdit = _db.Posts.Where(post => post.Slug == Slug).FirstOrDefault();
            return View(postToEdit);
        }
        return View(null);

    }

    [HttpPost]
    public IActionResult Edit(Post newPost)
    {
        if (ModelState.IsValid)
        {
            try
            {
                _db.Posts.Update(newPost);
                _db.SaveChanges();
                Post postEdited = _db.Posts.Where(post => post.PostId == newPost.PostId).FirstOrDefault();
                ViewData["Message"] = $"{newPost.Title} was added successfully";
                return View(postEdited);
            }
            catch (Exception e)
            {
                var errName = e.GetBaseException().Message;
                ViewData["Error"] = errName;
                Post postEdited = _db.Posts.Where(post => post.PostId == newPost.PostId).FirstOrDefault();
                return View(postEdited);

            }
        }
        else
        {
            Console.WriteLine("\nModel is invalid");

        }
        return View();

    }
}
