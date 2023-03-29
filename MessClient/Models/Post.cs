using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MessClient.Models
{

    public class Post
    {
        public int PostId {get; set;}
        public string MessageBody {get; set;}
        public DateTime Date {get; set;}
        public string MessageName { get; set; }
        // public int GroupId {get; set;}
        // public Group Group {get; set;}
        // //public string GroupName = _db.Groups.Find(GroupId).GroupName
        // public ApplicationUser ApplicationUser {get; set;}
        // public int UserId {get;set;}
    

    public static List<Post> GetPosts()
    {
      var apiCallTask = ApiHelper.GetAll();
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Post> postList = JsonConvert.DeserializeObject<List<Post>>(jsonResponse.ToString());

      return postList;
    }

    public static Post GetDetails(int id)
    {
      var apiCallTask = ApiHelper.Get(id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Post post = JsonConvert.DeserializeObject<Post>(jsonResponse.ToString());

      return post;

    }

    public static void Posted(Post posts)
    {
      string jsonPost = JsonConvert.SerializeObject(posts);
      ApiHelper.Post(jsonPost);
    }

  public static void Put(Post post)
    {
      string jsonPost = JsonConvert.SerializeObject(post);
      ApiHelper.Put(post.PostId, jsonPost);
    }

      public static void Delete(int id)
    {
      ApiHelper.Delete(id);
    }

  }
}
