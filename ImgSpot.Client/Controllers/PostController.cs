using System;
using System.Linq;
using System.Threading.Tasks;
//using System.Text.Json;
using ImgSpot.Client.Models;
using ImgSpot.Domain.Models;
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
    public IActionResult Post(PostModel jsonString)
    {
      if (ModelState.IsValid)
      {

        var settings = new JsonSerializerSettings
        {
          NullValueHandling = NullValueHandling.Ignore,
          MissingMemberHandling = MissingMemberHandling.Ignore
        };
        var post = new PostModel()
        {
          SelectedUser = jsonString.SelectedUser,
          SelectedComment = jsonString.SelectedComment,
          SelectedPicture = jsonString.SelectedPicture
        };
        //post = JsonConvert.DeserializeObject<PostModel>(jsonString, settings);
        //post.Load(_unitOfWork);

        var user = _unitOfWork.Users.Select(c => c.Username == post.SelectedUser).FirstOrDefault();
        var picture = _unitOfWork.Pictures.Select(c => (c.Filename == post.SelectedPicture)).FirstOrDefault();
        var comment = _unitOfWork.Comments.Select(c => (c.Body == post.SelectedComment)).FirstOrDefault();
        if (user == null && picture == null)
        {
          var newUser = new User();
          newUser.Username = post.SelectedUser;
          _unitOfWork.Users.Insert(newUser);//creates a new user if non exists 

          var newPic = new Picture();
          newPic.Filename = post.SelectedPicture;
          newPic.User = newUser;
          _unitOfWork.Pictures.Insert(newPic);
          //inserts a new picture with the new user
        }
        _unitOfWork.Save();
      }
      return Ok();
    }
  }
}