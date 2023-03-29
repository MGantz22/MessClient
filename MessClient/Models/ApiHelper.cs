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
  }
}