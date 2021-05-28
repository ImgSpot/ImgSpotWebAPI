using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ImgSpot.Domain.Models;
using ImgSpot.Storage;
using Newtonsoft.Json;

namespace ImgSpot.Client.Models
{
  public class PostModel //: IValidatableObject
  {

    public List<User> Users { get; set; }
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public List<Like> Likes { get; set; }
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]

    public List<Comment> Comments { get; set; }
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public List<Picture> Pictures { get; set; }

    public string SelectedUser { get; set; }
    public string SelectedLike { get; set; }
    public string SelectedComment { get; set; }
    public string SelectedPicture { get; set; }

    public void Load(UnitOfWork unitOfWork)
    {
      Users = unitOfWork.Users.Select(u => !string.IsNullOrWhiteSpace(u.Username)).ToList();
      //Likes = unitOfWork.Likes.Select(u => !string.IsNullOrWhiteSpace(u.)).ToList();
      Comments = unitOfWork.Comments.Select(u => !string.IsNullOrWhiteSpace(u.Body)).ToList();
      Pictures = unitOfWork.Pictures.Select(u => !string.IsNullOrWhiteSpace(u.Filename)).ToList();
    }
  }
}