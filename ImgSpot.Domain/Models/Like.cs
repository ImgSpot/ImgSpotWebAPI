using System.Collections.Generic;
using ImgSpot.Domain.Abstracts;

namespace ImgSpot.Domain.Models
{
  public class Like : Entity
  {
    public string PictureEntityId { get; set; }
    public List<User> Users { get; set; }
  }
}