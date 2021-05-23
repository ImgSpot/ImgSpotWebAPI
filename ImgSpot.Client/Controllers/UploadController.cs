using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
//do I need System....Http?

namespace ImgSpot.Client.Controllers
{
  //routing?
  public class UploadController : ControllerBase
  {
    [HttpGet]
    public IAsyncResult Get()
    {
      Console.Log("picture uploaded");
    }
  }
}