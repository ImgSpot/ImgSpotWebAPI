using System.Collections.Generic;
using ImgSpot.Domain.Abstracts;


namespace ImgSpot.Domain.Models
{
  public class Picture : Entity
  {
    public string Filename { get; set; } //primary key? or PictureEntityId? 
    public string Username { get; set; } //of uploader
    public string Title { get; set; }
    public string Description { get; set; }
    public List<Comment> Comments { get; set; }
  }
}