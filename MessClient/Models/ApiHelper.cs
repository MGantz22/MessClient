using System.Threading.Tasks;
using RestSharp;

namespace MessClient.Models
{
  public class ApiHelper
  {

// // Create a RestSharp client instance and set the API endpoint URL
// var client = new RestClient("https://example.com/api");

// // Create a RestRequest object for the POST request
// var request = new RestRequest(Method.POST);

// // Specify the request body data as form data
// request.AddParameter("name", "John");
// request.AddParameter("age", 30);

// // Execute the request and get the response
// var response = client.Execute(request);

// _______________________________________

// // Create a RestSharp client instance and set the API endpoint URL
// var client = new RestClient("https://example.com/api");

// // Create a RestRequest object for the POST request
// var request = new RestRequest(Method.POST);

// // Specify the request body data as a JSON object
// var bodyData = new { name = "John", age = 30 };
// request.AddJsonBody(bodyData);

// // Execute the request and get the response
// var response = client.Execute(request);

// ________________________________________



    public static async Task<string> LogIn(string username, string passWord)
    {
      RestClient client = new RestClient("http://localhost:7201/");
      RestRequest request = new RestRequest($"api/logins", Method.Post);
      // request.AddParameter("UserName", $"{userName}");
      // request.AddParameter("Password", $"{passWord}");
      var bodyData = new { userName = $"{username}", password = $"{passWord}"};
      RestResponse response = await client.ExecuteAsync(request);
      return response.Content;
    }
    public static async Task<string> GetAll()
    {
      RestClient client = new RestClient("http://localhost:7201/");
      RestRequest request = new RestRequest($"api/posts", Method.Get);
      RestResponse response = await client.GetAsync(request);
      return response.Content;
    }

    public static async Task<string> Get(int id)
    {
      RestClient client = new RestClient("http://localhost:7201/");
      RestRequest request = new RestRequest($"api/posts", Method.Get);
      RestResponse response = await client.GetAsync(request);
      return response.Content;
    }

    public static async void Post(string newPost)
    {
      RestClient client = new RestClient("http://localhost:7201/");
      RestRequest request = new RestRequest($"api/posts", Method.Post);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newPost);
      await client.PostAsync(request);
    }

    public static async void Put(int id, string newPost)
    {
      RestClient client = new RestClient("http://localhost:7201/");
      RestRequest request = new RestRequest($"api/post/{id}", Method.Put);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newPost);
      await client.PutAsync(request);
    }

    public static async void Delete(int id)
    {
      RestClient client = new RestClient("http://localhost:7201/");
      RestRequest request = new RestRequest($"api/Post/{id}", Method.Delete);
      request.AddHeader("Content-Type", "application/json");
      await client.DeleteAsync(request);
    }
  }
}