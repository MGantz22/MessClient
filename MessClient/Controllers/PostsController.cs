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

  public ActionResult Create()
  {
    return View();
  }

  [HttpPost]
  public ActionResult Create(Post post)
  {
    Post.Posted(post);
    return RedirectToAction("Index");

  }

  public ActionResult Edit(int id)
  {
    Post post = Post.GetDetails(id);
    return View(post);
  }

  [HttpPost]
  public ActionResult Edit(Post post)
  {
    Post.Put(post);
    return RedirectToAction("Details", new { id = post.PostId });
  }

  public ActionResult Delete(int id)
  {
    Post post = Post.GetDetails(id);
    return View(post);
  }

  [HttpPost, ActionName("Delete")]
  public ActionResult DeleteConfirmed(int id)
  {
    Post.Delete(id);
    return RedirectToAction("Index");
  }
}