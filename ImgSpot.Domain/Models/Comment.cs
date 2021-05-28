using System.Collections.Generic;
using ImgSpot.Domain.Abstracts;

namespace ImgSpot.Domain.Models
{
  public class Comment : Entity
  {
    public User User { get; set; } // reference the User
    public long UserEntityId { get; set; }
    public string Body { get; set; } //limited to 255 characters, twitter like? 
    public Picture Pictures { get; set; }
    public long PictureEntityId { get; set; }
  }
}