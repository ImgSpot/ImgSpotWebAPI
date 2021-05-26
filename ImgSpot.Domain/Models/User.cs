using System.Collections.Generic;
using ImgSpot.Domain.Abstracts;

namespace ImgSpot.Domain.Models
{
  public class User : Entity
  {
    public string Username { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public List<Picture> Pictures { get; set; }
    public List<Comment> Comments { get; set; }
    public List<Like> Likes { get; set; }
  }
}