using Microsoft.AspNetCore.Mvc;
using aspCMS.Models;
using aspCMS.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using aspCMS.Repository;

namespace aspCMS.Controllers;

public class CategoryController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public CategoryController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index(string? id)
    {
        return RedirectToAction("Category", "Category");
    }

    public IActionResult Category(string? id)
    {
        if (id == null || id == "fail")
        {
            return View(null);
        }
        else
        {

            Category categoryFound = _unitOfWork.Categories.GetPostBySlug(id);
            return View(postFound);
        }

    }

    
}
