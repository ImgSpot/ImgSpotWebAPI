using ImgSpot.Storage.Repositories;

namespace ImgSpot.Storage
{
  public class UnitOfWork
  {
    private readonly ImgSpotContext _context;
    public UserRepository Users { get; }
    public PictureRepository Pictures { get; set; }
    public CommentRepository Comments { get; set; }
    public LikeRepository Likes { get; set; }

    public UnitOfWork(ImgSpotContext context)
    {
      _context = context;
      Users = new UserRepository(_context);
      Pictures = new PictureRepository(_context);
      Comments = new CommentRepository(_context);
      Likes = new LikeRepository(_context);
    }
    public void Save()
    {
      _context.SaveChanges();
    }
  }
}