using Microsoft.AspNetCore.Mvc;
using MessClient.Models;

namespace MessClient.Controllers;

public class PostsController : Controller
{
  public IActionResult Index()
  {
    List<Post> posts = Post.GetPosts();
    return View(posts);
  }

    public IActionResult Details(int id)
  {
    Post post = Post.GetDetails(id);
    return View(post);
  }
}