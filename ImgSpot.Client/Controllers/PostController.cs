using Microsoft.AspNetCore.Mvc;

namespace ImgSpot.Client.Controllers
{
  [ApiController]
  [Route("[controller]")]

  public class PostController : ControllerBase
  {


    [HttpGet]
    [ValidateAntiForgeryToken]
    public IActionResult Upload()
    {

    }

    [HttpPost]
    [ValidateAntiForgeryToken]
  }
}