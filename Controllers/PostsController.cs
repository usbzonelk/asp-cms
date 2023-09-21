using Microsoft.AspNetCore.Mvc;
using aspCMS.Models;
using aspCMS.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using aspCMS.Repository;

namespace aspCMS.Controllers;

public class PostsController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public PostsController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index(string? id)
    {
        if (id == null || id == "fail")
        {
            return View(null);
        }
        else
        {
            Post postFound = _unitOfWork.Posts.GetPostBySlug(id);
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

            Post postFound = _unitOfWork.Posts.GetPostBySlug(id);
            return View(postFound);
        }

    }

    public IActionResult Create()
    {
        if (User.Identity.IsAuthenticated)
        {
            return View();
        }
        else
        {
            return RedirectToAction("Index", "Home");
        }
    }

    [HttpPost]
    public IActionResult Create(Post newPost)
    {
        if (ModelState.IsValid)
        {
            try
            {
                _unitOfWork.Posts.Add(newPost);
                _unitOfWork.Save();
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
        if (User.Identity.IsAuthenticated)
        {
            string? Slug = id;
            if (Slug != null)
            {
                Post postToEdit = _unitOfWork.Posts.GetPostBySlug(Slug);
                return View(postToEdit);
            }
            return View(null);
        }
        else
        {
            return RedirectToAction("Index", "Home");
        }


    }

    [HttpPost]
    public IActionResult Edit(Post newPost)
    {
        if (ModelState.IsValid)
        {
            try
            {
                _unitOfWork.Posts.EditPost(newPost);
                _unitOfWork.Save();
                Post postEdited = _unitOfWork.Posts.Get(post => post.PostId == newPost.PostId);
                ViewData["Message"] = $"{newPost.Title} was added successfully";
                return View(postEdited);
            }
            catch (Exception e)
            {
                var errName = e.GetBaseException().Message;
                ViewData["Error"] = errName;
                Post postEdited = _unitOfWork.Posts.Get(post => post.PostId == newPost.PostId);
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
