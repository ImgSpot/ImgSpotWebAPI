using System;
using System.Collections.Generic;
using System.Linq;
using ImgSpot.Domain.Models;
using ImgSpot.Domain.Interfaces;

namespace ImgSpot.Storage.Repositories
{
  public class LikeRepository : IRepository<Like>
  {
    private readonly ImgSpotContext _context;
    public LikeRepository(ImgSpotContext context)
    {
      _context = context;
    }
    public IEnumerable<Like> Select(Func<Like, bool> filter)
    {
      return _context.Likes.Where(filter);
    }
    public bool Insert(Like entry)
    {
      _context.Likes.Add(entry);
      return true;
    }
    public Like Update()
    {
      throw new System.NotImplementedException();
    }
    public bool Delete()
    {
      throw new System.NotImplementedException();
    }
  }
}