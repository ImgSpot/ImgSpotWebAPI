using System.Linq;
//using System.Text.Json;
using ImgSpot.Client.Models;
using ImgSpot.Storage;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ImgSpot.Client.Controllers
{
  [ApiController]
  [Route("[controller]")]
  [EnableCors("public")]
  public class PostController : ControllerBase
  {
    public readonly UnitOfWork _unitOfWork;
    public PostController(UnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }



    [HttpGet]
    //[ValidateAntiForgeryToken]
    public IActionResult Get()
    {
      var settings = new JsonSerializerSettings
      {
        NullValueHandling = NullValueHandling.Ignore,
        MissingMemberHandling = MissingMemberHandling.Ignore
      };
      //return likes, comments, pictures
      var post = new PostModel();
      post.Load(_unitOfWork);
      string jsonString = JsonConvert.SerializeObject(post, settings);
      //serialize into json string
      //return Ok( serialized json string );
      return Ok(jsonString);

    }
    [HttpPost]
    //[ValidateAntiForgeryToken]
    public IActionResult Post(string jsonString)
    {
      var settings = new JsonSerializerSettings
      {
        NullValueHandling = NullValueHandling.Ignore,
        MissingMemberHandling = MissingMemberHandling.Ignore
      };
      var post = new PostModel();
      post = JsonConvert.DeserializeObject<PostModel>(jsonString, settings);
      //post.Load(_unitOfWork);
      /*
     var user = _unitOfWork.Users.Select(c => c.Username == post.SelectedUser).First();
     var picture = _unitOfWork.Pictures.Select(c => (c.Username == post.SelectedPicture) && (c.Filename == post.SelectedPicture)).First();
     var comment = _unitOfWork.Comments.Select(c => (c.Username == post.SelectedComment) && (c.Filename == post.SelectedComment)).First();

     _unitOfWork.Users.Insert(user);
     _unitOfWork.Pictures.Insert(picture);
     _unitOfWork.Comments.Insert(comment); */

      _unitOfWork.Save();
      return Ok(post);
    }


  }
}