using Microsoft.AspNetCore.Mvc;

namespace ImgSpot.Client.Controllers
{
  [ApiController]
  [Route("[controller]")]

  public class PictureController : ControllerBase
  {


    [HttpGet]
    [HttpPost]
    [ValidateAntiForgeryToken]

    public IActionResult Upload()
    {

    }
  }
}