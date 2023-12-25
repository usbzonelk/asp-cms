using Microsoft.AspNetCore.Mvc;
using aspCMS.Models;
using aspCMS.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace aspCMS.Controllers;

public class PostsController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public PostsController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public class CreatePostModal
    {
        public Post post;
        public List<Category> categories;

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
            List<Category> Categories = _unitOfWork.Categories.GetAll();
            List<String> SelectedCategories = Categories.Select(category => category.CategoryName.ToString()).ToList();
            TempData["CategoriesAll"] = SelectedCategories.ToList<string>();

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
                if (newPost.Category != null)
                {
                    int catId = newPost.Category.CategoryId;
                    if (_unitOfWork.Categories.Get(newCat => newCat.CategoryId == catId) == null)
                    {
                        _unitOfWork.Categories.Add(newPost.Category);
                    }
                }
                _unitOfWork.Save();
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

            Console.WriteLine("l");

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
            foreach (var key in ModelState.Keys)
            {
                var errors = ModelState[key].Errors;
                if (errors.Count > 0)
                {
                    Console.WriteLine($"Validation errors for {key}:");
                    foreach (var error in errors)
                    {
                        Console.WriteLine($"- {error.ErrorMessage}");
                    }
                }
            }
        }
        return View();

    }
}
