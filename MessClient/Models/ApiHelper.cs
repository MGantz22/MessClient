using System.Threading.Tasks;
using RestSharp;

namespace MessClient.Models
{
  public class ApiHelper
  {
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