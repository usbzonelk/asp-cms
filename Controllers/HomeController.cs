using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using aspCMS.Models;
using aspCMS.Data;
using HtmlAgilityPack;
using aspCMS.Repository;

namespace aspCMS.Controllers;

public class HomeController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public HomeController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()

    {
        List<Post> postsList = _unitOfWork.Posts.GetAll();
        foreach (var post in postsList)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(post.Content);
            string text = doc.DocumentNode.InnerText.Trim();

            int length = text.Length;
            if (length > 60)
            {
                length = 60;
            }
            post.Content = text.Substring(0, length);

        }
        return View(postsList);

    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
