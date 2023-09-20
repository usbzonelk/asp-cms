using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using aspCMS.Models;
using aspCMS.Data;
using HtmlAgilityPack;
using aspCMS.Repository.PostsRepository;

namespace aspCMS.Controllers;

public class HomeController : Controller
{
    private readonly IPostsRepository postsRepo;

    public HomeController(IPostsRepository _posts)
    {
        postsRepo = _posts;
    }

    public IActionResult Index()

    {
        List<Post> postsList = postsRepo.GetAll();
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
