using System;
using ImgSpot.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ImgSpot.Storage
{
  public class ImgSpotContext : DbContext
  {
    public DbSet<User> Users { get; set; }
    public DbSet<Like> Likes { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Picture> Pictures { get; set; }
    public ImgSpotContext(DbContextOptions options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<User>().HasKey(e => e.EntityId);
      builder.Entity<Like>().HasKey(e => e.EntityId);
      builder.Entity<Comment>().HasKey(e => e.EntityId);
      builder.Entity<Picture>().HasKey(e => e.EntityId);
      OnDataSeeding(builder);
    }
    protected void OnDataSeeding(ModelBuilder builder)
    {
      //if I wanted to seed the data
      builder.Entity<User>().HasData(new User[]
      {
        new User() { EntityId = 1, Username = "Testuser1", Firstname = "Jon", Lastname = "Doe"}
      });

    }
  }
}
