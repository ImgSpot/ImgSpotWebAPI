using ImgSpot.Domain.Abstracts;

namespace ImgSpot.Domain.Models
{
  public class Comment : Entity
  {
    public string Username { get; set; } // reference the User
    public string Filename { get; set; } // reference the Picture
    public string Body { get; set; } //limited to 255 characters, twitter like? 
  }
}