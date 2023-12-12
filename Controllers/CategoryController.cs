using Microsoft.AspNetCore.Mvc;
using aspCMS.Models;
using aspCMS.Repository;

namespace aspCMS.Controllers;

public class CategoryController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public CategoryController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        List<Category> categories = _unitOfWork.Categories.GetAll();

        return View(categories);
    }

    public IActionResult Posts(string? id)
    {
        if (id == null || id == "fail")
        {
            return View(null);
        }
        else
        {
            List<Post> postsWithCategory = _unitOfWork.Posts.GetAll(post => post.Category.CategoryId.ToString() == id.ToString());
            return View(postsWithCategory);
        }

    }
    public IActionResult Edit(string? id)
    {
        if (id != null || id != "fail")

        {
            Category chosenCategory = _unitOfWork.Categories.Get(category => category.CategoryId.ToString() == id.ToString());
            if (chosenCategory != null)
            {
                return View(chosenCategory);
            }
        }
        return View(null);

    }

    [HttpPost]
    public IActionResult Edit(Category userCategory)
    {
        if (ModelState.IsValid)
        {
            if (User.Identity.IsAuthenticated)
            {
                try
                {
                    _unitOfWork.Categories.EditCategory(userCategory);
                    _unitOfWork.Save();
                    Category UpdatedCategory = _unitOfWork.Categories.Get(category => category.CategoryName == userCategory.CategoryName);
                    ViewData["Message"] = $"{userCategory.CategoryName} was updated successfully";
                    return View(UpdatedCategory);
                }
                catch (Exception e)
                {
                }
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
        return View("Index");
    }


}
