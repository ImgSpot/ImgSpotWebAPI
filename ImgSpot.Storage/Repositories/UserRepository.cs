using System;
using System.Collections.Generic;
using System.Linq;
using ImgSpot.Domain.Models;
using ImgSpot.Domain.Interfaces;

namespace ImgSpot.Storage.Repositories
{
  public class UserRepository : IRepository<User>
  {
    private readonly ImgSpotContext _context;
    public UserRepository(ImgSpotContext context)
    {
      _context = context;
    }
    public IEnumerable<User> Select(Func<User, bool> filter)
    {
      return _context.Users.Where(filter);
    }
    public bool Insert(User entry)
    {
      throw new System.NotImplementedException();
    }
    public User Update()
    {
      throw new System.NotImplementedException();
    }
    public bool Delete()
    {
      throw new System.NotImplementedException();
    }
  }
}