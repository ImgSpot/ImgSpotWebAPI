using System.Collections.Generic;
using ImgSpot.Domain.Abstracts;

namespace ImgSpot.Domain.Models
{
  public class Like : Entity
  {
    public string PictureEntityId { get; set; } // references the picture
    public string Username { get; set; } // references the Username or I can switch to PK_UserEntityId
  }
}