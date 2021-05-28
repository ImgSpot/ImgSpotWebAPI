using ImgSpot.Domain.Models;
using Xunit;

namespace ImgSpot.Testing.Tests
{
  public class ModelTests
  {
    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void Test_Comment()
    {
      var sut = new Comment()
      {
        User = new User() { Username = "Fred" },
        Body = "Is a Comment"
      };

      Assert.True(sut.User.Username == "Fred");
      Assert.True(sut.Body == "Is a Comment");
    }

    [Fact]
    public void Test_Like()
    {
      var sut = new Like()
      {
        Picture = new Picture() { Filename = "Cats.jpg" },
        User = new User() { Username = "Fred" }
      };

      Assert.True(sut.Picture.Filename == "Cats.jpg");
      Assert.True(sut.User.Username == "Fred");
    }

    [Fact]
    public void Test_Picture()
    {
      var sut = new Picture()
      {
        Filename = "Cats.jpg",
        User = new User() { Username = "Fred" },
        Title = "Cat",
        Description = "This is a cat"
      };

      Assert.True(sut.Filename == "Cats.jpg");
      Assert.True(sut.User.Username == "Fred");
      Assert.True(sut.Title == "Cat");
      Assert.True(sut.Description == "This is a cat");
    }

    [Fact]
    public void Test_User()
    {
      var sut = new User()
      {
        Username = "Fred01",
        Firstname = "Fred",
        Lastname = "Lastname"
      };

      Assert.True(sut.Username == "Fred01");
      Assert.True(sut.Firstname == "Fred");
      Assert.True(sut.Lastname == "Lastname");
    }
  }
}