using Microsoft.AspNetCore.Mvc;
using aspCMS.Models;
using aspCMS.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Options;
using aspCMS.Repository;
using aspCMS.Repository.PostsRepository;

namespace aspCMS.Controllers;

public class PostsController : Controller
{
    private readonly IPostsRepository postsRepo;

    public PostsController(IPostsRepository postsRepo)
    {
        postsRepo = postsRepo;
    }

    public IActionResult Index(string? id)
    {


        if (id == null || id == "fail")
        {
            return View(null);
        }
        else
        {
            Post postFound = postsRepo.GetPostBySlug(id);
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

            Post postFound = postsRepo.GetPostBySlug(id);
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
                postsRepo.Add(newPost);
                // _db.SaveChanges();
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
            Post postToEdit = postsRepo.GetPostBySlug(Slug);
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
                postsRepo.EditPost(newPost);
                Post postEdited = postsRepo.Get(post => post.PostId == newPost.PostId);
                ViewData["Message"] = $"{newPost.Title} was added successfully";
                return View(postEdited);
            }
            catch (Exception e)
            {
                var errName = e.GetBaseException().Message;
                ViewData["Error"] = errName;
                Post postEdited = postsRepo.Get(post => post.PostId == newPost.PostId);
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
