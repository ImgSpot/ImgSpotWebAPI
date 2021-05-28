using System.Collections.Generic;
using ImgSpot.Domain.Abstracts;


namespace ImgSpot.Domain.Models
{
  public class Picture : Entity
  {
    public string Filename { get; set; } //primary key? or PictureEntityId? 
    public User User { get; set; } //of the uploader
    public long UserEntityId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int CountLikes { get; set; }
    public List<Comment> Comments { get; set; }
  }
}