using System.Collections.Generic;
using ImgSpot.Domain.Abstracts;

namespace ImgSpot.Domain.Models
{
  public class Like : Entity
  {
    public Picture Picture { get; set; }
    public long PictureEntityId { get; set; } // references the picture
    public User User { get; set; }// references the Username
    public long UserEntityId { get; set; }

  }
}