using Microsoft.AspNetCore.Mvc;
using MessClient.Models;

namespace MessClient.Controllers;

public class LoginController : Controller
{
  public string bearerToken {get;set;}
  public LoginController(IConfiguration configuration)
  {

  }

  public IActionResult Login()
  {
    return View();
  }

  [HttpPost]
  public IActionResult Login(string userName, string passWord)
  {
    Task<string> apiCallTask = ApiHelper.LogIn(userName, passWord);
    bearerToken = apiCallTask.Result;
    
    ViewBag.Response = apiCallTask.Result;
    return RedirectToAction("Index");
  }
}