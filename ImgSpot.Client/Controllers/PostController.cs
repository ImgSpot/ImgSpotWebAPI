using System.Text.Json;
using ImgSpot.Client.Models;
using ImgSpot.Storage;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ImgSpot.Client.Controllers
{
  [ApiController]
  [Route("[controller]/post")]
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
      //return likes, comments, pictures
      var post = new PostModel();
      post.Load(_unitOfWork);
      string jsonString = JsonSerializer.Serialize(post);
      //serialize into json string
      //return Ok( serialized json string );
      return Ok(jsonString);
    }

    [HttpPost]
    //[ValidateAntiForgeryToken]
    public IActionResult Post(string jsonString)
    {
      var post = new PostModel();
      post = JsonSerializer.Deserialize<PostModel>(jsonString);
      post.Load(_unitOfWork);
      _unitOfWork.Save();
      return Ok(post);
    }
  }
}