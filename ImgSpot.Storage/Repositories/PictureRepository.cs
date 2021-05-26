using System;
using System.Collections.Generic;
using System.Linq;
using ImgSpot.Domain.Models;
using ImgSpot.Domain.Interfaces;

namespace ImgSpot.Storage.Repositories
{
  public class PictureRepository : IRepository<Picture>
  {
    private readonly ImgSpotContext _context;
    public PictureRepository(ImgSpotContext context)
    {
      _context = context;
    }
    public IEnumerable<Picture> Select(Func<Picture, bool> filter)
    {
      return _context.Pictures.Where(filter);
    }
    public bool Insert(Picture entry)
    {
      throw new System.NotImplementedException();
    }
    public Picture Update()
    {
      throw new System.NotImplementedException();
    }
    public bool Delete()
    {
      throw new System.NotImplementedException();
    }
  }
}