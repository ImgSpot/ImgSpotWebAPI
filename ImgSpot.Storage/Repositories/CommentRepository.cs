using System;
using System.Collections.Generic;
using System.Linq;
using ImgSpot.Domain.Models;
using ImgSpot.Domain.Interfaces;

namespace ImgSpot.Storage.Repositories
{
  public class CommentRepository : IRepository<Comment>
  {
    private readonly ImgSpotContext _context;
    public CommentRepository(ImgSpotContext context)
    {
      _context = context;
    }
    public IEnumerable<Comment> Select(Func<Comment, bool> filter)
    {
      return _context.Comments.Where(filter);
    }
    public bool Insert(Comment entry)
    {
      _context.Comments.Add(entry);
      return true;
    }
    public Comment Update()
    {
      throw new System.NotImplementedException();
    }
    public bool Delete()
    {
      throw new System.NotImplementedException();
    }
  }
}