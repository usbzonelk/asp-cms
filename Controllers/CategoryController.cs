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


}
